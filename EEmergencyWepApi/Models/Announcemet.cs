using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EEmergencyWebApi.Models
{
    public class Announcemet
    {
        [Key]
        public int id { set; get; }

        public string title { set; get; }

        public string readMore { set; get; }
        
    }
}
