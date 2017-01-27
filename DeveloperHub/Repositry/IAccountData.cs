using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DeveloperHub.Models.User;
namespace DeveloperHub.Repositry
{
    public interface IAccountData
    {
        int GetUserIdByUserName(string userName);
       List<UserProfileMapper> GetAllRegisterUsers();
       UserProfileMapper GetUserProfiles(string userName, int id);
    }
}