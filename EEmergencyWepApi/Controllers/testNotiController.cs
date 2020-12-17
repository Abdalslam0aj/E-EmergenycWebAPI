using EEmergencyWebApi.Models.sharedServices;
using EEmergencyWepApi.Data.module;
using EEmergencyWepApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EEmergencyWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class testNotiController : Controller
    {
        ConctionDbClass db;

        public testNotiController(ConctionDbClass db)
        {
            this.db = db;
        }

        public async Task<ActionResult<bool>> sendNotificatonAsync(string token, string title, string body)
        {

           // GISService gIS = new GISService(db);
           // Location l = new Location(31.99112660685779, 35.896513012894864);
          //  gIS.findNearestResponseTeam(l,1);
           return await Notificationcs.sendNotificatonAsync(token,title,body);
            


        }
    }
}
