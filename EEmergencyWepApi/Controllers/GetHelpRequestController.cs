using EEmergencyWebApi.Models.HelpRequestClasses;
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
    public class GetHelpRequestController : Controller
    {
        ConctionDbClass db;
        public GetHelpRequestController(ConctionDbClass db)
        {
            this.db = db;
        }

        [HttpGet]
        public ActionResult<HelpRequest> getHelpRequest([FromForm] ParamedicData data)
        {
            Mission myMission = new Mission(db);
            HelpRequest helpMission = myMission.getHelpRequest(data.phoneNumber);
           
            return helpMission;
        }
    }
    public class ParamedicData
    {
        public string phoneNumber { set; get; }
        
        public ParamedicData()
        {
            this.phoneNumber = phoneNumber;
           
        }
    }
}
