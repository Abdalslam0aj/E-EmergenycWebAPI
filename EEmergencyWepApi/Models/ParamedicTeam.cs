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
        public int teamNumber { set; get; }

        public int deploymentLocation { set; get; }

        public string status { set; get; }

    }
}
