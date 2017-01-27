using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeveloperHub.Models.User
{
    public interface IUserInfo
    {
       bool CheckUserExist(string userName);
       
    }
}