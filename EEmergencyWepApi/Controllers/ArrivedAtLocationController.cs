using EEmergencyWebApi.Models;
using EEmergencyWebApi.Models.Const;
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
    public class ArrivedAtLocationController : Controller
    {
        ConctionDbClass db;
        public ArrivedAtLocationController (ConctionDbClass db)
        {
            this.db = db;
        }
        [HttpPost]
        public async Task<ActionResult<Hospital>> IndexAsync([FromForm] Arrived finished)
        {
            HelpRequest request = new HelpRequest();
            request.civilianPhoneNumber = finished.civilianPhoneNumber;
            RecivedHelpRequest recivedHelpRequest = new RecivedHelpRequest(request, db);
            bool nearlocation = false;

            if (recivedHelpRequest.checkExists()) {
              HelpRequest requestToSet=  recivedHelpRequest.getRequest();
              nearlocation = GISService.isThere(new Location(requestToSet.latitude, requestToSet.longitude), new Location(finished.myLatitude,finished.myLongitude));
                if (nearlocation)
                {
                    requestToSet.status = HelpStatus.arrived;
                    db.HelpRequest.Update(requestToSet);
                    db.SaveChanges();
                    GISService service = new GISService(db);
                    Location paramedicLocation = new Location(finished.myLatitude, finished.myLongitude);
                    Hospital hospital = service.findNearestHospital(paramedicLocation);

                    var token = db.Civilian.Find(requestToSet.civilianPhoneNumber).notificationToken;
                    await Notificationcs.sendNotificatonAsync(token, "paramedic arrived!", "the paramedic has arrived at your location");
                    return hospital;

                }
                else
                    return new Hospital();
            } else 
           


            return new Hospital(); 
        }
        public class Arrived {
            public string civilianPhoneNumber { set; get; }           
            public double myLatitude { set; get; }

            public double myLongitude { set; get; }

        }
    }
}
