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
    public class EndRequestController : Controller
    {
        ConctionDbClass db;
        public EndRequestController (ConctionDbClass db)
        {
            this.db = db;
        }
        [HttpPost]
        public ActionResult<bool> Index([FromForm] Arrived finished)
        {


            return GISService.isThere(new Location(31.991154472104824, 35.89672655403522), new Location(31.991089345182953, 35.89609994129383)); 
        }
        public class Arrived {
            public String civilianPhoneNumber { set; get; }
            public double civilianLatitude { set; get; }

            public double CivilianLongitude { set; get; }
            public double myLatitude { set; get; }

            public double myLongitude { set; get; }

        }
    }
}
