using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EEmergencyWepApi.Data;
using EEmergencyWepApi.Models;
using EEmergencyWepApi.Data.module;
using Microsoft.Extensions.Configuration;
using EEmergencyWebApi.Models;

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
    public class LoginUserController : ControllerBase
    {
        ConctionDbClass db;
        public LoginUserController(ConctionDbClass db) { 
        this.db=db;
        }

        [HttpPost]
        public ActionResult<User> login([FromForm] Login loginInformation)
        {

            string phoneNumber = loginInformation.phoneNumber;
            User loginRequester = db.Users.Find(phoneNumber);
            if (loginRequester != null)
            {//To Do Login



            }
            else {

                return null;
            
            }
            string password = loginInformation.password;
            Civilian civilianLogin = new Civilian();
            civilianLogin.phoneNumber = phoneNumber;
            civilianLogin.password = password;

            Civilian foundCivilian = db.Civilian.Find(civilianLogin.phoneNumber);
            if (foundCivilian != null)
            {


            }
            return foundCivilian;

        }
    }
}
