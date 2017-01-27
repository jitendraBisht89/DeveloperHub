using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeveloperHub.Models.User
{
    public class User
    {
        public int Id { set; get; }
        public string UserName { set; get; }
        public string Email { set; get; }
        public List<UserProfile> userProfiles;
    }
}