using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityMapping.AccountData
{
 public  interface IEntityAccountData
    {
    int GetUserIdByUserName(string userName);
    List<Users> GetAllRegisterUsers();
    Users GetUserProfiles(string userName, int id);
    int UpdateUserProfile(UserProfile userProfile);
    
    }
}
