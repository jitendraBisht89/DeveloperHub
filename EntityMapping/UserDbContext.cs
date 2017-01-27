using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Reflection;
using System.Data.Entity.ModelConfiguration;
namespace EntityMapping
{
  public  class UserDbContext:DbContext
    {
      public UserDbContext userDbContext;
      public UserDbContext(): base("Db")
      {
         
      }
        public DbSet<Users> Users { set; get; }
        public DbSet<UserProfile> Userprofile { set; get; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Configurations.Add(new UserMap());
               modelBuilder.Configurations.Add(new UserProfileMap());
            base.OnModelCreating(modelBuilder);
        }

        public int AddUserEntity<T>(T userEntity)where T:Users
        {
            userDbContext = new UserDbContext();
            userDbContext.Users.Add(userEntity);
            return 1;
        }

        public Users CheckUserExist(string userName)
        {
            userDbContext = new UserDbContext();
            Users usersName = userDbContext.Users.Where(x => x.UserName.Equals(userName)).SingleOrDefault();
            return usersName;
        }
        
    }
}
