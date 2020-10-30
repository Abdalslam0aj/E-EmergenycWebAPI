using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EEmergencyWebAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EEmergencyWepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        

         [HttpPost]
        public ActionResult<bool> login(string phoneNumber, string password)
        {
            
            bool a = true;
            


            return a;

        }
    }
}
