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
    [Authorize]
    public class DCDsController : Controller
    {
        private EEmergencyDataBaseEntities db = new EEmergencyDataBaseEntities();

        // GET: DCDs
       
        public ActionResult Index()
        {
            var dCDs = db.DCDs.Include(d => d.ParamedicTeam);
            return View(dCDs.ToList());
        }

        // GET: DCDs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DCD dCD = db.DCDs.Find(id);
            if (dCD == null)
            {
                return HttpNotFound();
            }
            return View(dCD);
        }

        // GET: DCDs/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.ParamedicTeams, "teamNumber", "status");
            return View();
        }

        // POST: DCDs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,name,latitude,longitude")] DCD dCD)
        {
            if (ModelState.IsValid)
            {
                db.DCDs.Add(dCD);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.ParamedicTeams, "teamNumber", "status", dCD.Id);
            return View(dCD);
        }

        // GET: DCDs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DCD dCD = db.DCDs.Find(id);
            if (dCD == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.ParamedicTeams, "teamNumber", "status", dCD.Id);
            return View(dCD);
        }

        // POST: DCDs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,name,latitude,longitude")] DCD dCD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dCD).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.ParamedicTeams, "teamNumber", "status", dCD.Id);
            return View(dCD);
        }

        // GET: DCDs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DCD dCD = db.DCDs.Find(id);
            if (dCD == null)
            {
                return HttpNotFound();
            }
            return View(dCD);
        }

        // POST: DCDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DCD dCD = db.DCDs.Find(id);
            db.DCDs.Remove(dCD);
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
