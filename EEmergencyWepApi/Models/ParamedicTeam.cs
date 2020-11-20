using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EEmergencyWepApi.Models
{
    public class ParamedicTeam
    {
        [Key]
        int teamNumber { set; get; }

        int deploymentLocation { set; get; }

    }
}
