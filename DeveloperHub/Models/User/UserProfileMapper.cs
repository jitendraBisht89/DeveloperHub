using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DeveloperHub.Models.User;
namespace DeveloperHub.Models.User
{
    public class UserProfileMapper
    {
        public int Id { set; get; }
        public string LastName { set; get; }
        public int PhoneNumber { set; get; }
        public string Address { set; get; }
        public string UserName { set; get; }
        public string Email { set; get; }
        public string imgPath { set; get; }
    }
}