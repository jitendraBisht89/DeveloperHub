using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntityMapping.AccountData;
using DeveloperHub.Models.User;
using AutoMapper;
using EntityMapping;
namespace DeveloperHub.Repositry
{
    #region
    public class AccountData:IAccountData
    {
        private IEntityAccountData iEntityAccountData;
        public AccountData()
        {
            iEntityAccountData = new EntityAccountData();
        }
        public int GetUserIdByUserName(string userName)
        {
            int userId = iEntityAccountData.GetUserIdByUserName(userName);
            
            return userId;
        }
        public  List<UserProfileMapper> GetAllRegisterUsers()
        {
            
             Mapper.CreateMap<EntityMapping.Users,DeveloperHub.Models.User.UserProfileMapper>();
             List<EntityMapping.Users> userComplieteListFromEntity = iEntityAccountData.GetAllRegisterUsers();
             List<UserProfileMapper> userPro = new List<UserProfileMapper>();
             foreach( var users in userComplieteListFromEntity)
             {
                 DeveloperHub.Models.User.UserProfileMapper userProfileModel = Mapper.Map<EntityMapping.Users, UserProfileMapper>(users);
                 userPro.Add(userProfileModel);
             }

             return userPro;

        }
        public  UserProfileMapper GetUserProfiles(string userName, int id)
        {
            Mapper.CreateMap<EntityMapping.Users, DeveloperHub.Models.User.UserProfileMapper>();
            EntityMapping.Users useProfile = iEntityAccountData.GetUserProfiles(userName, id);
            DeveloperHub.Models.User.UserProfileMapper userPofileMapper = Mapper.Map<EntityMapping.Users, UserProfileMapper>(useProfile);
            return userPofileMapper;

        }
    }
    #endregion
}