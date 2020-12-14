using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EEmergencyWebApi.Models
{
    public class TeamsAssigendLog
    {

        [Key]
        public int id { set; get; }

        public int teamNumber { set; get; }
    }
}
