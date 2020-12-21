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
    public class CheckRequestController : Controller
    {
        ConctionDbClass db;

        public CheckRequestController (ConctionDbClass db)
        {
            this.db = db;
        }
        [HttpPost]
        public ActionResult<bool> Index([FromForm] HelpRequest help)
        {
            var requestFinished = db.HelpRequest.Where(e => e.civilianPhoneNumber == help.civilianPhoneNumber);
            if (requestFinished.Count() == 0)
            {

                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
