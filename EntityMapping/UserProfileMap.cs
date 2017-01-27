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
    class UserProfileMap:EntityTypeConfiguration<UserProfile>
    {
        public UserProfileMap()
        {
            HasKey(t =>t.Id);
            Property(t => t.AddedDate).IsRequired();
            Property(t => t.ModifiedDate).IsRequired();
            Property(t => t.imgPath).IsRequired();
            Property(t => t.LastName);
            Property(t => t.PhoneNumber);
            Property(t => t.Address).IsRequired();
            //table  
            ToTable("UserProfiles");
            HasRequired(t => t.User).WithRequiredDependent(u => u.UserProfile);  

        }
    }
}
