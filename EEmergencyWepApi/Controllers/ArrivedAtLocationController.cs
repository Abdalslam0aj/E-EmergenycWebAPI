using EEmergencyWebApi.Models;
using EEmergencyWebApi.Models.Const;
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
        public ActionResult<bool> Index([FromForm] Arrived finished)
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
                    return true;

                } else
                return false;
            } else 
           


            return false; 
        }
        public class Arrived {
            public string civilianPhoneNumber { set; get; }           
            public double myLatitude { set; get; }

            public double myLongitude { set; get; }

        }
    }
}
