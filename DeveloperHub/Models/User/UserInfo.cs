using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntityMapping;

namespace DeveloperHub.Models.User
{
    public class UserInfo : IUserInfo
    {
        public bool CheckUserExist(string userName)
        {
           
            var userExsit = false;
            UserDbContext userDb = new UserDbContext();
            Users singleUserList = userDb.CheckUserExist(userName);
            if (singleUserList != null)
            {
                userExsit = true;
            }
             return userExsit;
        }
    }
}