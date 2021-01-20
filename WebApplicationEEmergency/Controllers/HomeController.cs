using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WebApplicationEEmergency.Controllers
{
    
    public class HomeController : Controller
    {
        private EEmergencyDataBaseEntities db = new EEmergencyDataBaseEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin admin, string ReturnUrl)
        {
           Admin adminToLogin= db.Admins.Where(e=> e.email==admin.email && e.password == admin.password).ToArray()[0];
            Console.WriteLine(adminToLogin.fullName);
            if (adminToLogin != null)
            {
                Console.WriteLine(adminToLogin.fullName);
                FormsAuthentication.SetAuthCookie(adminToLogin.fullName, false);
                
                Console.WriteLine(FormsAuthentication.Timeout+"");
                return RedirectToAction("Index");
            }
           
            return View(admin);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}