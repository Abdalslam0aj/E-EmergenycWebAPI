using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace EEmergencyWepApi.Models
{
    public class Hospital
    {
        [Key]
        public int hospitalid { set; get; }

        public string name { set; get; }

        public double latitude { set; get; }

        public double longitude { set; get; }
    }
}
