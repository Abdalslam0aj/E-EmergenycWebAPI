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
    public class GetUserInfoController : Controller
    {
        ConctionDbClass db;
        public GetUserInfoController(ConctionDbClass db)
        {
            this.db = db;
        }
        public ActionResult<Civilian> Index([FromBody]Civilian civilian)
        {
            try {
                Civilian user = db.Civilian.Find(civilian.phoneNumber);
                return user;
            }
            catch (Exception e) {
                Console.WriteLine(e);
                return new Civilian();
            }
         
        }
    }
}
