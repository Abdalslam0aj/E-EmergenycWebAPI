using EEmergencyWepApi.Data.module;
using EEmergencyWepApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EEmergencyWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParamedicTravelTimeController : Controller
    {
        ConctionDbClass db;
        public ParamedicTravelTimeController(ConctionDbClass db)
        {
            this.db = db;
        }
        public ActionResult<string> Index([FromForm] TwoLocation location)
        {
            GISService gIS = new GISService(db);

            Location cvilianLocation = new Location(location.civilianLat, location.civilianLong);
            Location paramedicLocation = new Location(location.paramedicLat, location.paramedicLong);
            
            var time = gIS.nearestDuration(cvilianLocation, paramedicLocation) + 120;

           
            return ""+time;
        }

    }
    public class TwoLocation {
        public TwoLocation() { }
       public double paramedicLat { get; set; }
        public double paramedicLong { get; set; }
        public double civilianLat { get; set; }
        public double civilianLong { get; set; }


    }
}
