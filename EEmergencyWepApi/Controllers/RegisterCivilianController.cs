using EEmergencyWebApi.Models.operations;
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
    public class RegisterCivilianController : Controller
    {
        ConctionDbClass db;
        public RegisterCivilianController(ConctionDbClass db)
        {
            this.db = db;
        }
        public ActionResult<bool> Index([FromForm] Civilian civilian)
        {
            bool c = false;
            Console.WriteLine(civilian.phoneNumber);
            RegisterController registerController = new RegisterController(db);
            c=registerController.RegisterCivilan(civilian);

            return c;
        }
    }
}
