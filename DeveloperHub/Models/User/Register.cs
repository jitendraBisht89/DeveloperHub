using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace DeveloperHub.Models
{
    public class Register
    {
        [Required(ErrorMessage = "User Name can not be blank")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Invalid User  Name")]
        [System.Web.Mvc.Remote("CheckUserNameExists", "Account", ErrorMessage = "Username already exists!")]
        public string username { get; set; }

        [RegularExpression(@"^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$", ErrorMessage = "Email Required")]
        [Required(ErrorMessage = "Email Cant be Blank")]
        public string EmailID { get; set; }

        
        [Required(ErrorMessage = "Password can not be blank")]
        [RegularExpression("^(?=.*[0-9])(?=.*[a-zA-Z])([a-zA-Z0-9]+)$", ErrorMessage = "pssword invalid")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password { get; set; }

        
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("password", ErrorMessage = "The password and confirmation password do not match.")]
        public string Confirmpassword { get; set; }
    }
}