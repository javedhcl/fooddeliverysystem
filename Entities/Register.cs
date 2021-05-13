using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace fooddeliverysystem.Models
{
    public class Register
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please use letters only.")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}", ErrorMessage = "Invalid email")]

        public string Email { get; set; }
        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Mobile number must be numeric.")]
        [StringLength(10, ErrorMessage = "The mobile must contains 10 numerics", MinimumLength = 10)]
        public string Mobile { get; set; }

        public string Address { get; set; }
    }
}