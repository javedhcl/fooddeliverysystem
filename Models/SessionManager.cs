using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace fooddeliverysystem
{
    public class SessionManager
    {
        private const string USER_ID_SESSION_KEY = "UserId";
        private const string USER_NAME_SESSION_KEY = "UserName";
        private const string isAdmin_SESSION_KEY = "IsAdmin";

        public bool IsValidSession
        {
            get
            {
                return HttpContext.Current.Session[USER_ID_SESSION_KEY] != null && Convert.ToInt32(HttpContext.Current.Session[USER_ID_SESSION_KEY]) > 0;
            }
        }

        private T GetFromSession<T>(string key)
        {
            return (T)HttpContext.Current.Session[key];
        }

        private void SetInSession(string key, object value)
        {
            HttpContext.Current.Session[key] = value;
        }
        public int UserId
        {
            get { return GetFromSession<int>(USER_ID_SESSION_KEY); }
            set { SetInSession(USER_ID_SESSION_KEY, value); }
        }
        public string UserName
        {
            get { return GetFromSession<string>(USER_NAME_SESSION_KEY); }
            set { SetInSession(USER_NAME_SESSION_KEY, value); }
        }
        public bool isAdmin
        {
            get { return GetFromSession<bool>(isAdmin_SESSION_KEY); }
            set { SetInSession(isAdmin_SESSION_KEY, value); }
        }
    }
}




