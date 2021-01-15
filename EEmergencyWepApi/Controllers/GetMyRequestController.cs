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
    public class GetMyRequestController : Controller
    {
        ConctionDbClass db;

        public GetMyRequestController(ConctionDbClass db)
        {
            this.db = db;
        }
        public ActionResult<HelpRequest> Index([FromForm] Civilian civilian)
        {
            var request = db.HelpRequest.Where(e => e.civilianPhoneNumber == civilian.phoneNumber).ToArray();

            return request[0];
        }
    }
}
