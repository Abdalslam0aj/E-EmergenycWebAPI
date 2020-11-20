using EEmergencyWepApi.Data.module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EEmergencyWepApi.Models
{
    public class GISService
    {
        ConctionDbClass db;

        GISService(ConctionDbClass db) {
            this.db = db;
        }

        public ParamedicTeam findNearestResponseTeam (Location helpRequestLocation) {

            List<DCD> a= db.DCD.ToList();
            foreach (DCD i in a) {
             
            }

            return new ParamedicTeam();
        }

        private ParamedicTeam nearestDistence(Location cvilianLocation,Location paramsmedicLocation) {

            return new ParamedicTeam();
        }

        private ParamedicTeam fastestRoute()
        {

            return new ParamedicTeam();
        }

    }
}
