using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace EEmergencyWepApi.Models
{
    public class Admin
    {  
        [Key]
        public string email { set; get; }
        public string password { set; get; }

        public string fullName { set; get; }


    }
}
