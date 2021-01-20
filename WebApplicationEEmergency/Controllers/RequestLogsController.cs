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
    public class RequestLogsController : Controller
    {
        private EEmergencyDataBaseEntities db = new EEmergencyDataBaseEntities();

        // GET: RequestLogs
        public ActionResult Index()
        {
            var requestLogs = db.RequestLogs.Include(r => r.Hospital1).Include(r => r.TeamsAssigendLog);
            return View(requestLogs.ToList());
        }

        // GET: RequestLogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestLog requestLog = db.RequestLogs.Find(id);
            if (requestLog == null)
            {
                return HttpNotFound();
            }
            return View(requestLog);
        }

        // GET: RequestLogs/Create
        public ActionResult Create()
        {
            ViewBag.hospital = new SelectList(db.Hospitals, "hospitalId", "Name");
            ViewBag.id = new SelectList(db.TeamsAssigendLogs, "id", "id");
            return View();
        }

        // POST: RequestLogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,civilianPhoneNumber,latitude,longitude,description,timeOfArrival,timeOfEnd,hospital")] RequestLog requestLog)
        {
            if (ModelState.IsValid)
            {
                db.RequestLogs.Add(requestLog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.hospital = new SelectList(db.Hospitals, "hospitalId", "Name", requestLog.hospital);
            ViewBag.id = new SelectList(db.TeamsAssigendLogs, "id", "id", requestLog.id);
            return View(requestLog);
        }

        // GET: RequestLogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestLog requestLog = db.RequestLogs.Find(id);
            if (requestLog == null)
            {
                return HttpNotFound();
            }
            ViewBag.hospital = new SelectList(db.Hospitals, "hospitalId", "Name", requestLog.hospital);
            ViewBag.id = new SelectList(db.TeamsAssigendLogs, "id", "id", requestLog.id);
            return View(requestLog);
        }

        // POST: RequestLogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,civilianPhoneNumber,latitude,longitude,description,timeOfArrival,timeOfEnd,hospital")] RequestLog requestLog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(requestLog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.hospital = new SelectList(db.Hospitals, "hospitalId", "Name", requestLog.hospital);
            ViewBag.id = new SelectList(db.TeamsAssigendLogs, "id", "id", requestLog.id);
            return View(requestLog);
        }

        // GET: RequestLogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestLog requestLog = db.RequestLogs.Find(id);
            if (requestLog == null)
            {
                return HttpNotFound();
            }
            return View(requestLog);
        }

        // POST: RequestLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RequestLog requestLog = db.RequestLogs.Find(id);
            db.RequestLogs.Remove(requestLog);
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
