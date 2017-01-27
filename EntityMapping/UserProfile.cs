using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EntityMapping
{
    public class UserProfile : UserBaseEntity
    { 
        public string imgPath { set; get; }
        public string LastName { set; get; }
        public int PhoneNumber { set; get; }
        public string Address { set; get; }
        public virtual Users User { get; set; }  
        
    }
}
