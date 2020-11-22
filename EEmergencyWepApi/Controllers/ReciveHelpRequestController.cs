using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using EEmergencyWepApi.Data.module;
using EEmergencyWepApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EEmergencyWepApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReciveHelpRequestController : ControllerBase
    {
        ConctionDbClass db;
        ReciveHelpRequestController(ConctionDbClass db) {
            this.db = db;
        }

        [HttpGet]
        public ActionResult<bool> reciveHelpRequest([FromForm] HelpRequest helpRequest) {

            db.HelpRequest.Add(helpRequest);
            db.SaveChanges();
            //TO DO add Recived help request and call assgin then save in db


              
            return true;
           
        }
    }
}
