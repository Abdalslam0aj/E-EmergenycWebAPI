using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EEmergencyWepApi.Models
{
    public class TeamMembers
    {
        [Key]
        public int teamNumber { set; get; }

        public string phoneNumber { set; get; }
    }
}
