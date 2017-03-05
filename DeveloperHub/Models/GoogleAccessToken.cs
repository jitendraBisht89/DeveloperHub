using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeveloperHub.Models
{
    public class GoogleAccessToken
    {
        public string AccessToken { get; set; }
        public string UserName { set; get; }
        public string Email { set; get; }
    }
}