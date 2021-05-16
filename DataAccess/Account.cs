using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fooddeliverysystem.Models
{
    public class Account
    {
        public Crud_Context cd = new Crud_Context();
        public int? ValidateLogin(Login_tbl model)
        {
            var login = cd.Login_tbls.FirstOrDefault(a => a.UserName.ToLower() == model.UserName.ToLower()
            && a.Password == model.Password);

            if (login != null)
            {
                return login.UserID;
            }
            else
            {
                return null;
            }
        }

        public void Register(Register model)
        {
            // new user id = last max userId +1;
            //int newUserId = cd.user_tbls.Max(a => a.UserID) + 1;

            // new user entity creation
            user_tbl userEntity = new user_tbl
            {
                //UserID = newUserId,
                Name = model.Name,
                Address = model.Address,
                Email = model.Email,
                Mobile = model.Mobile,
                RoleId = 2
            };

            // new login entity creation
            Login_tbl loginEntity = new Login_tbl
            {
                // ID = cd.Login_tbls.Max(a => a.UserID) + 1,
                UserID = userEntity.UserID,
                UserName = model.UserName,
                Password = model.Password,

            };

            // addding new user entity in table
            cd.user_tbls.Add(userEntity);

            // adding new login entity for new user in login table
            cd.Login_tbls.Add(loginEntity);

            // to save all changes in database
            cd.SaveChanges();
        }

        public user_tbl GetUserDetail(int userId)
        {
            user_tbl userDetail = cd.user_tbls
                .Include("UserRoles")
                .SingleOrDefault(a => a.UserID == userId);

            user_tbl userModel = new user_tbl
            {
                UserID = userDetail.UserID,
                Name = userDetail.Name,
                Address = userDetail.Address,
                Email = userDetail.Email,
                Mobile = userDetail.Mobile,
                isAdmin = userDetail.userRoles.Any(a => a.RoleID == 1)

            };
            return userDetail;
        }

    }
}