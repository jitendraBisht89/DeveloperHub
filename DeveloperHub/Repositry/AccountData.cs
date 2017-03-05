using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntityMapping.AccountData;
using DeveloperHub.Models.User;
using AutoMapper;
using EntityMapping;
using System.Data.SqlClient;
using System.Configuration;
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
        public int UpdateUserProfile(UserProfileMapper userProfile)
        {
            Mapper.CreateMap< DeveloperHub.Models.User.UserProfileMapper,EntityMapping.UserProfile>();
            EntityMapping.UserProfile userList = Mapper.Map<UserProfileMapper,EntityMapping.UserProfile>(userProfile);
            int status=  iEntityAccountData.UpdateUserProfile(userList);
            return status;
        }
       public void UnBlockUser()
        {
        }
       public string GetUserInRole(string  userName) 
       {
           string userRole = "";
           SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Db"].ToString());
           con.Open();
           SqlCommand cmd = new SqlCommand("select RoleName from webpages_Roles, webpages_UsersInRoles where UserId=@UserId and RoleName='SystemUser'", con);
           cmd.Parameters.AddWithValue("@UserId", GetUserIdByUserName(userName));
           SqlDataReader sdr = cmd.ExecuteReader();
           while (sdr.Read())
           {
               userRole = sdr["RoleName"].ToString();
           }
           con.Close();
           return userRole;
       }

       
    }
    #endregion
}