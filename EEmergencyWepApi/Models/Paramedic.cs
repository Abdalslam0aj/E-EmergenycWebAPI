using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EEmergencyWepApi.Models
{
    public class Paramedic
    {
        [Key]
        public string phoneNumber { set; get; }

        public string password { set; get; }

        public string NIDN { set; get; }

        public string fullName { set; get; }

        public string status { set; get; }

        public string notificationToken { set; get; }

        public int team { set; get; }

    }
}
