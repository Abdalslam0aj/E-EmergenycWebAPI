using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EEmergencyWebAPI.Data
{
    public class HelpRequest {

        string phoneNumber;
        string longtitude;
        string latitude;

        HelpRequest(string phoneNumber, string longtitude, string latitude) {
            this.phoneNumber = phoneNumber;
            this.longtitude = longtitude;
            this.latitude = latitude;
        }

        public bool assignRequest() {
            bool accepted = false;
            //ToDo find best suted paramedic
            Location paramedicLocation;
            Location civilanLocation = new Location(Double.Parse(longtitude),Double.Parse(latitude));
            //to do range time 
         


            return accepted;
        }





    }
}
