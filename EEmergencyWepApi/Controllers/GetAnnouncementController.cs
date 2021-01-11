using EEmergencyWebApi.Models;
using EEmergencyWepApi.Data.module;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EEmergencyWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetAnnouncementController : Controller
    {
        ConctionDbClass db;
        public GetAnnouncementController(ConctionDbClass db)
        {
            this.db = db;
        }
        [HttpGet]
        public ActionResult<Announcemet> Index()
        {
            
            return db.Announcemet.Find(1);
        }
    }
}
