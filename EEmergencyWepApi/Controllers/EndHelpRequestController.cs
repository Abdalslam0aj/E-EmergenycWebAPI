using EEmergencyWebApi.Models.HelpRequestClasses;
using EEmergencyWepApi.Data.module;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EEmergencyWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EndHelpRequestController : Controller
    {
        ConctionDbClass db;

        public EndHelpRequestController(ConctionDbClass db)
        {
            this.db = db;
        }

        [HttpPost]
        public ActionResult<bool> Index([FromForm] ParamedicData data)
        {
            Mission missionToEnd = new Mission(db);
            bool ended = missionToEnd.EndHelpRequest(data.phoneNumber);

            return ended;
        }
    }






}
