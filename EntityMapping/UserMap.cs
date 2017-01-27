using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using EntityMapping;
namespace EntityMapping
{
    class UserMap:EntityTypeConfiguration<Users>
    {
        public UserMap()
        {
            HasKey(t => t.Id);
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);  
            Property(t => t.Email).IsRequired();
            Property(t => t.UserName).IsRequired();
            Property(t => t.AddedDate).IsRequired();
            Property(t => t.ModifiedDate).IsRequired();
            
            ToTable("Users");
           
        }
    }
}
