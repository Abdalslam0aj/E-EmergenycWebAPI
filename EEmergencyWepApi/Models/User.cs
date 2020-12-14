using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EEmergencyWebApi.Models
{
    public class User
    {
        [Key]
        string phoneNumber { set; get; }

        string userType { set; get; }

    }
}
