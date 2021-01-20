using EEmergencyWebApi.Models;
using EEmergencyWepApi.Data.module;
using EEmergencyWepApi.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EEmergencyWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResetPasswordController : Controller
    {
        ConctionDbClass db;
        public ResetPasswordController(ConctionDbClass db)
        {
            this.db = db;
        }
        public ActionResult<bool> Index([FromForm] User user)
        {
            try
            {
                User userToRestPassword = db.Users.Find(user.phoneNumber);
                if (userToRestPassword != null)
                {
                    var mail = new MimeMessage();
                    Random r = new Random();
                    int n = r.Next(1, 999999);
                    string password = "AoutoGen" + n + "2f";
                    mail.From.Add(new MailboxAddress("password reset", "eemergencysystem@gmail.com"));
                    if (userToRestPassword.userType == "paramedic")
                    {
                        Paramedic paramedic = db.Paramedic.Find(userToRestPassword.phoneNumber);
                        paramedic.password = password;
                        db.Paramedic.Update(paramedic);
                        mail.To.Add(new MailboxAddress("user", paramedic.email));
                    }
                    else
                    {
                        Civilian civilian = db.Civilian.Find(userToRestPassword.phoneNumber);
                        civilian.password = password;
                        db.Civilian.Update(civilian);
                        mail.To.Add(new MailboxAddress("user", civilian.email));
                    }
                    db.SaveChanges();

                   
                    mail.Subject = "password rest for EEmergency: ";
                    mail.Body = new TextPart("plain")
                    {
                        Text = password + " :is your new password"
                    };
                    using (var client = new SmtpClient())
                    {

                        client.Connect("smtp.gmail.com", 587, false);
                        client.Authenticate("eemergencysystem@gmail.com", "123456789ALJAMAL");
                        client.Send(mail);
                        client.Disconnect(true);
                    }
                    return true;
                }
                    return false;
            } catch (Exception e) {
                return false;
            }
        }
    }
}
