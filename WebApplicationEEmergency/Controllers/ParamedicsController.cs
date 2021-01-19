using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplicationEEmergency;

namespace WebApplicationEEmergency.Controllers
{
    public class ParamedicsController : Controller
    {
        private EEmergencyDataBaseEntities db = new EEmergencyDataBaseEntities();

        // GET: Paramedics
        public ActionResult Index()
        {
            var paramedics = db.Paramedics.Include(p => p.ParamedicTeam).Include(p => p.User);
            return View(paramedics.ToList());
        }

        // GET: Paramedics/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paramedic paramedic = db.Paramedics.Find(id);
            if (paramedic == null)
            {
                return HttpNotFound();
            }
            return View(paramedic);
        }

        // GET: Paramedics/Create
        public ActionResult Create()
        {
            ViewBag.Team = new SelectList(db.ParamedicTeams, "teamNumber", "status");
            ViewBag.phoneNumber = new SelectList(db.Users, "phoneNumber", "userType");
            return View();
        }

        // POST: Paramedics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "phoneNumber,password,NIDN,fullname,status,notificationToken,Team")] Paramedic paramedic)
        {
            if (ModelState.IsValid)
            {
                db.Paramedics.Add(paramedic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Team = new SelectList(db.ParamedicTeams, "teamNumber", "status", paramedic.Team);
            ViewBag.phoneNumber = new SelectList(db.Users, "phoneNumber", "userType", paramedic.phoneNumber);
            return View(paramedic);
        }

        // GET: Paramedics/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paramedic paramedic = db.Paramedics.Find(id);
            if (paramedic == null)
            {
                return HttpNotFound();
            }
            ViewBag.Team = new SelectList(db.ParamedicTeams, "teamNumber", "status", paramedic.Team);
            ViewBag.phoneNumber = new SelectList(db.Users, "phoneNumber", "userType", paramedic.phoneNumber);
            return View(paramedic);
        }

        // POST: Paramedics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "phoneNumber,password,NIDN,fullname,status,notificationToken,Team")] Paramedic paramedic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paramedic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Team = new SelectList(db.ParamedicTeams, "teamNumber", "status", paramedic.Team);
            ViewBag.phoneNumber = new SelectList(db.Users, "phoneNumber", "userType", paramedic.phoneNumber);
            return View(paramedic);
        }

        // GET: Paramedics/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paramedic paramedic = db.Paramedics.Find(id);
            if (paramedic == null)
            {
                return HttpNotFound();
            }
            return View(paramedic);
        }

        // POST: Paramedics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Paramedic paramedic = db.Paramedics.Find(id);
            db.Paramedics.Remove(paramedic);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
