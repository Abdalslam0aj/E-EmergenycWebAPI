using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace EEmergencyWepApi.Models
{
    public class HelpRequest
    {
        [Key]
        public int id { set; get; }

        public string civilianPhoneNumber { set; get; }

        public double latitude { set; get; }

        public double longitude { set; get; }

        public string status { set; get; }

        public string description { set; get; }

        public DateTime timeOfArrivel { set; get; }

        public DateTime timeOfEnd { set; get; }

        public int numberOfHumans { set; get; }

        public int hospital { set; get; }


    }
}
