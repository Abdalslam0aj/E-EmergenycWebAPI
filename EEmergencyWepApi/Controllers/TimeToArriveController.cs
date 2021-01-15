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
    public class TimeToArriveController : Controller
    {
        ConctionDbClass db;

        public TimeToArriveController(ConctionDbClass db)
        {
            this.db = db;
        }
        public ActionResult<HelpRequest> Index([FromForm] Civilian civilian)
        {
            HelpRequest requestTime=new HelpRequest();           
            var request = db.HelpRequest.Where(e => e.civilianPhoneNumber == civilian.phoneNumber).ToArray();
            requestTime = request[0];
            GISService gIS=new  GISService(db);
            var teams =db.HelpRequestAssigned.Where(e => e.id == requestTime.id).ToArray();
            var teamNo=teams[0].teamNumber;
            var dcd=db.ParamedicTeams.Find(teamNo);
            var dcdRequest=db.DCD.Find(dcd.deploymentLocation);

            Location cvilianLocation= new Location(requestTime.latitude,requestTime.longitude);
            Location paramedicLocation = new Location(dcdRequest.latitude, dcdRequest.longitude);
            //60 seconds for + -
            var time =gIS.nearestDuration(cvilianLocation,paramedicLocation)+120;           

            requestTime.timeOfEnd = request[0].timeOfArrivel.AddSeconds(time);
            

            return requestTime;
        }
    }
}
