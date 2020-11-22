using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EEmergencyWebAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EEmergencyWepApi.Data;
using EEmergencyWepApi.Models;
using EEmergencyWepApi.Data.module;
using Microsoft.Extensions.Configuration;

namespace EEmergencyWepApi.Controllers
{
    public class Login {
        public string phoneNumber { set; get; }
        public string password { set; get; }
        public string notiToken { set; get; }
        public Login() {
            this.phoneNumber = phoneNumber;
            this.password = password;
            this.notiToken = notiToken;
        }
    }
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        ConctionDbClass db;
        public LoginController(ConctionDbClass db) { 
        this.db=db;
        }
        
         [HttpPost]
        public async Task<ActionResult<Civilian>> login([FromForm]Login loginInformation)
        {
            string phoneNumber= loginInformation.phoneNumber;
            string password= loginInformation.password;
            Civilian civilianLogin = new Civilian();
            civilianLogin.phoneNumber = phoneNumber;
            civilianLogin.password = password;
            
            Civilian foundCivilian= db.Civilian.Find(civilianLogin.phoneNumber);
            if (foundCivilian != null) { 
            
            
            }
            return foundCivilian;

        }
    }
}
