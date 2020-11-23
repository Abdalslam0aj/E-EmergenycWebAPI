using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using EEmergencyWebApi.Models;
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
        public ReciveHelpRequestController(ConctionDbClass db) {
            this.db = db;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> reciveHelpRequestAsync([FromForm] HelpRequest helpRequest) {

            db.HelpRequest.Add(helpRequest);
            db.SaveChanges();
            //TO DO add Recived help request and call assgin then save in db
            RecivedHelpRequest recivedHelp = new RecivedHelpRequest(helpRequest,db);
            HelpRequestAssigned requestAssigned= await recivedHelp.assigenHelpRequestAsync();
            db.HelpRequestAssigned.Add(requestAssigned);
            db.SaveChanges();


            return true;
           
        }
    }
}
