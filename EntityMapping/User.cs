using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EntityMapping
{
    public class Users : UserBaseEntity
    {
        public string UserName { set; get; }
        public string Email { set; get; }
        public  UserProfile UserProfile { get; set; }
        public bool status { set; get; }
    }
}
