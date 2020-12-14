using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EEmergencyWebApi.Models
{
    public class RequestLog
    {
        [Key]
        public int id { set; get; }

        public string civilianPhoneNumber { set; get; }

        public double latitude { set; get; }

        public double longitude { set; get; }
   
        public string description { set; get; }

        public DateTime timeOfArrivel { set; get; }

        public DateTime timeOfEnd { set; get; }
    }
}
