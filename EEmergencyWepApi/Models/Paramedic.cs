using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EEmergencyWepApi.Models
{
    public class Paramedic
    {
        [Key]

        string phoneNumber { set; get; }

        string password { set; get; }

        string NIDN { set; get; }

        string fullName { set; get; }

        string status { set; get; }

        string notificationToken { set; get; }

    }
}
