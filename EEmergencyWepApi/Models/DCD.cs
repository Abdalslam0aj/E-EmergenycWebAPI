using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace EEmergencyWepApi.Models
{
    public class DCD
    {
        [Key]
       public int id { set; get; }

       public string name { set; get; }

       public double latitude { set; get; }

       public double longitude { set; get; }
    }
}
