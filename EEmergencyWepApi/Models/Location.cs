using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EEmergencyWepApi.Models
{
    public class Location
    {
       // public Location() { }
       
        public Location( double latitude,double longitude) {
            this.latitude = latitude;
            this.longitude = longitude;
        }

        public double latitude { get; set; }
        public double longitude { get; set; }
      

    }
}
