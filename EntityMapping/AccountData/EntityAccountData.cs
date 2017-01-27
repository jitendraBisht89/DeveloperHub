using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace EntityMapping.AccountData
{
    #region
    public  class EntityAccountData:IEntityAccountData
    {
     private UserDbContext userDbContext;
     public EntityAccountData()
      {
          userDbContext = new UserDbContext();
      }
        public int GetUserIdByUserName(string userName)
        {
            var u=  userDbContext.Users.Where(x => x.UserName.Equals(userName)).Select(x=>x.Id).SingleOrDefault();
            int userId = Convert.ToInt32(u);
            
            return userId;
        }

        public List<Users> GetAllRegisterUsers()
        {
          List <Users> listAllUsers=  userDbContext.Users.Include(x => x.UserProfile).ToList();

          return listAllUsers;
        }
        
        public Users GetUserProfiles(string userName, int id)
        {
            Users userProfile = userDbContext.Users.Include(x => x.UserProfile).Where(x => x.Id == id && x.UserName.Equals(userName)).SingleOrDefault();
            return userProfile;
        }

    }
    #endregion
}
