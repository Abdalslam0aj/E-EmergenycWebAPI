using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace EEmergencyWepApi.Models
{
    public class HelpRequestAssigned
    { 
        [Key]
        public int id { set; get; }

        public int teamNumber { set; get; }

    }
}
