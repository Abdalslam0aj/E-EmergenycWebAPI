using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EEmergencyWepApi.Models
{
    public class Civilian
    {
        [Key]
       public string phoneNumber { set; get; }

        public string password { set; get; }

        public string NIDN { set; get; }
        public string FullName { set; get; }

        public string bloodType { set; get; }

        public string birthDate { set; get; }

        public string email { set; get; }

        public string medicalCondition { set; get; }
    }
}
