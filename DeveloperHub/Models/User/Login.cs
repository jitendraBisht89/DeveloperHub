using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace DeveloperHub.Models.User
{
    public class Login
    {
        [Required(ErrorMessage = "Password can not be blank")]
        [RegularExpression("^(?=.*[0-9])(?=.*[a-zA-Z])([a-zA-Z0-9]+)$", ErrorMessage = "pssword invalid")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Enter User name")]
        public string UserName { get; set; }
    }
}