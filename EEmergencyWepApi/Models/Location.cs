using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EEmergencyWepApi.Models
{
    public class Location
    {
       // public Location() { }
       
        public Location(double longitude, double latitude) {
            this.latitude = latitude;
            this.longitude = longitude;
        }

        public double latitude { get; }
        public double longitude { get; }
      

    }
}
