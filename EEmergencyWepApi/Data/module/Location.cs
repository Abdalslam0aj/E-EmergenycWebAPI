using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EEmergencyWebAPI.Data
{
    public class Location
    {
        double longtitude;
        double latitude;

      public Location(double longtitude, double latitude) {
            this.longtitude = longtitude;
            this.latitude = latitude;
        }



    }
}
