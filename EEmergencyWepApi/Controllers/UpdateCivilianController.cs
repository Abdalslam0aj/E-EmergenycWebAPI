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
    public class UpdateCivilianController : Controller
    {
        ConctionDbClass db;

        public UpdateCivilianController(ConctionDbClass db)
        {
            this.db = db;
        }
        public ActionResult<bool> Index([FromForm] Civilian civilian)
        {

            // if (db.Civilian.Find(civilian.phoneNumber) != null)
            ///  {
              //      User user=new User();
            //        user.phoneNumber= civilian.phoneNumber;
            //        user.userType = "civilian";
            //        db.Users.Update(user);
             //       db.SaveChanges(); 
                    db.Civilian.Update(civilian);
                    db.SaveChanges();
                    return true;
              //  }
              //  return false;
           
           
        }
    }
}
