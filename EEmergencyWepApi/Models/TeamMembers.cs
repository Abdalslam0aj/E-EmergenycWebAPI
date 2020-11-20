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
        int teamNumber { set; get; }

        string phoneNumber { set; get; }
    }
}
