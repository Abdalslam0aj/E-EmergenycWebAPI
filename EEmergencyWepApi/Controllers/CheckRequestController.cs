using EEmergencyWebApi.Models;
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
            RecivedHelpRequest recivedHelpRequest = new RecivedHelpRequest(help,db);
            return recivedHelpRequest.checkExists();
        }
    }
}
