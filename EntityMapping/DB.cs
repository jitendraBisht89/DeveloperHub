using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
namespace EntityMapping
{
  public  class DB:DbContext
    {
      
     public DB(): base("Db")
    {
    }
     protected override void OnModelCreating(DbModelBuilder modelBuilder)
     {
         
         modelBuilder.Configurations.Add(new UserMap());
         modelBuilder.Configurations.Add(new UserProfileMap());
         base.OnModelCreating(modelBuilder);
     }  
    }
}
