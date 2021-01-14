using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using EEmergencyWebApi.Models;
using EEmergencyWebApi.Models.Const;
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
        public async Task<ActionResult<string>> reciveHelpRequestAsync([FromForm] HelpRequest helpRequest) {
            
            helpRequest.status = HelpStatus.running;
            //To do check for location with the same area
            var requestFinished=db.HelpRequest.Where(e=>e.civilianPhoneNumber==helpRequest.civilianPhoneNumber);
            
            if (requestFinished.Count()==0)
            {
                Console.WriteLine("help rquest is new and assigning sequence statrted arrived on "+ DateTime.Now);
                helpRequest.timeOfArrivel = DateTime.Now;
                //1 for no hospital assgined
                helpRequest.hospital = 1;
                db.HelpRequest.Add(helpRequest);
                db.SaveChanges();
                Console.WriteLine("help rquest is saved in running state ");
                //TO DO add Recived help request and call assgin then save in db
                RecivedHelpRequest recivedHelp = new RecivedHelpRequest(helpRequest, db);
                var requestsAssigned =  await recivedHelp.assigenHelpRequestAsync();
                db.HelpRequestAssigned.Add(requestsAssigned[0]);
                db.SaveChanges();
                
                

                Console.WriteLine(" help request is assgiend to a parmedic team ");
                return helpRequest.status;
                
            }


            return "helpRequestExists";
           
        }
    }
}
