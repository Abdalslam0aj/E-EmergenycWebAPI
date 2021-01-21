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
    public class ParamedicTeamsController : Controller
    {
        private EEmergencyDataBaseEntities db = new EEmergencyDataBaseEntities();

        // GET: ParamedicTeams1
        public ActionResult Index()
        {
            var paramedicTeams = db.ParamedicTeams.Include(p => p.DCD).Include(p => p.DCD1);
            return View(paramedicTeams.ToList());
        }

        // GET: ParamedicTeams1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParamedicTeam paramedicTeam = db.ParamedicTeams.Find(id);
            if (paramedicTeam == null)
            {
                return HttpNotFound();
            }
            return View(paramedicTeam);
        }

        // GET: ParamedicTeams1/Create
        public ActionResult Create()
        {
            ViewBag.teamNumber = new SelectList(db.DCDs, "Id", "name");
            ViewBag.deploymentLocation = new SelectList(db.DCDs, "Id", "name");
            return View();
        }

        // POST: ParamedicTeams1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "teamNumber,deploymentLocation,status")] ParamedicTeam paramedicTeam)
        {
            if (ModelState.IsValid)
            {
                db.ParamedicTeams.Add(paramedicTeam);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.teamNumber = new SelectList(db.DCDs, "Id", "name", paramedicTeam.teamNumber);
            ViewBag.deploymentLocation = new SelectList(db.DCDs, "Id", "name", paramedicTeam.deploymentLocation);
            return View(paramedicTeam);
        }

        // GET: ParamedicTeams1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParamedicTeam paramedicTeam = db.ParamedicTeams.Find(id);
            if (paramedicTeam == null)
            {
                return HttpNotFound();
            }
            ViewBag.teamNumber = new SelectList(db.DCDs, "Id", "name", paramedicTeam.teamNumber);
            ViewBag.deploymentLocation = new SelectList(db.DCDs, "Id", "name", paramedicTeam.deploymentLocation);
            return View(paramedicTeam);
        }

        // POST: ParamedicTeams1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "teamNumber,deploymentLocation,status")] ParamedicTeam paramedicTeam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paramedicTeam).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.teamNumber = new SelectList(db.DCDs, "Id", "name", paramedicTeam.teamNumber);
            ViewBag.deploymentLocation = new SelectList(db.DCDs, "Id", "name", paramedicTeam.deploymentLocation);
            return View(paramedicTeam);
        }

        // GET: ParamedicTeams1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParamedicTeam paramedicTeam = db.ParamedicTeams.Find(id);
            if (paramedicTeam == null)
            {
                return HttpNotFound();
            }
            return View(paramedicTeam);
        }

        // POST: ParamedicTeams1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ParamedicTeam paramedicTeam = db.ParamedicTeams.Find(id);
            db.ParamedicTeams.Remove(paramedicTeam);
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
