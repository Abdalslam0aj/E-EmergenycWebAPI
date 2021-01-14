using EEmergencyWebApi.Models.HelpRequestClasses;
using EEmergencyWebApi.Models.sharedServices;
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
    public class UpdateDescriptionController : Controller
    {
        ConctionDbClass db;
        public UpdateDescriptionController(ConctionDbClass db)
        {
            this.db = db;
        }

        [HttpPost]
        public async Task<ActionResult<HelpRequest>> IndexAsync([FromForm] HelpRequest requestToUpdate)
        {
            try
            {
                HelpRequest request = db.HelpRequest.Where(e => e.civilianPhoneNumber == requestToUpdate.civilianPhoneNumber).ToArray()[0];
                request.description = request.description + " " + requestToUpdate.description;
                db.HelpRequest.Update(request);
                db.SaveChanges();
                var teamAssgiend = db.HelpRequestAssigned.Where(e=>e.id==request.id).ToArray();
                var teamNumber =teamAssgiend[0].teamNumber;
                Console.WriteLine("notifying team members NT:sd");
                List<TeamMembers> teamMembers = db.TeamMembers.Where(e => e.teamNumber == teamNumber).ToList();

                foreach (var t in teamMembers)
                {
                    Paramedic paramedic = db.Paramedic.Find(t.phoneNumber);
                    bool d = await Notificationcs.sendNotificatonAsync(paramedic.notificationToken, "civilian has updated his status", requestToUpdate.description);
                    paramedic.status = d.ToString();
                    Console.WriteLine("notifying team members NT:" + paramedic.notificationToken + " notification sent ? " + d);
                   

                }


                return request;
            }
            catch (Exception e) {

                return new HelpRequest();
            
            }
        }
    }
}
