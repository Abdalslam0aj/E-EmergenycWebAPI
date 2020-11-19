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
    
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        ConctionDbClass db;
        public LoginController(ConctionDbClass db) { 
        this.db=db;
        }
        
         [HttpPost]
        public async Task<ActionResult<string>> loginAsync([FromBody] string content)
        {

            

            // ConctionDbClass db = new ConctionDbClass();
            Civilian c= new Civilian();
            c.FullName = "ahmad";
            c.phoneNumber = "0487";
            c.medicalCondition = "Retared";
            c.NIDN = "2000064";
            c.bloodType = "O+";
            c.birthDate = "2/jan/19";
            c.email = "abood@.com";
            c.password = "12345679";
           
           
         //  db.Add(c);
          //  db.SaveChanges();
            bool a;
            a = true;

          
          

            return content;

        }
    }
}
