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
    public class helpRequestsController : Controller
    {
        private EEmergencyDataBaseEntities db = new EEmergencyDataBaseEntities();

        // GET: helpRequests
        public ActionResult Index()
        {
            var helpRequests = db.helpRequests.Include(h => h.Civilian).Include(h => h.Hospital1);
            return View(helpRequests.ToList());
        }

        // GET: helpRequests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            helpRequest helpRequest = db.helpRequests.Find(id);
            if (helpRequest == null)
            {
                return HttpNotFound();
            }
            return View(helpRequest);
        }

        // GET: helpRequests/Create
        public ActionResult Create()
        {
            ViewBag.civilianPhoneNumber = new SelectList(db.Civilians, "phoneNumber", "password");
            ViewBag.hospital = new SelectList(db.Hospitals, "hospitalId", "Name");
            return View();
        }

        // POST: helpRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,civilianPhoneNumber,latitude,longitude,status,description,timeOfArrivel,timeOfEnd,numberOfHumans,hospital")] helpRequest helpRequest)
        {
            if (ModelState.IsValid)
            {
                db.helpRequests.Add(helpRequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.civilianPhoneNumber = new SelectList(db.Civilians, "phoneNumber", "password", helpRequest.civilianPhoneNumber);
            ViewBag.hospital = new SelectList(db.Hospitals, "hospitalId", "Name", helpRequest.hospital);
            return View(helpRequest);
        }

        // GET: helpRequests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            helpRequest helpRequest = db.helpRequests.Find(id);
            if (helpRequest == null)
            {
                return HttpNotFound();
            }
            ViewBag.civilianPhoneNumber = new SelectList(db.Civilians, "phoneNumber", "password", helpRequest.civilianPhoneNumber);
            ViewBag.hospital = new SelectList(db.Hospitals, "hospitalId", "Name", helpRequest.hospital);
            return View(helpRequest);
        }

        // POST: helpRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,civilianPhoneNumber,latitude,longitude,status,description,timeOfArrivel,timeOfEnd,numberOfHumans,hospital")] helpRequest helpRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(helpRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.civilianPhoneNumber = new SelectList(db.Civilians, "phoneNumber", "password", helpRequest.civilianPhoneNumber);
            ViewBag.hospital = new SelectList(db.Hospitals, "hospitalId", "Name", helpRequest.hospital);
            return View(helpRequest);
        }

        // GET: helpRequests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            helpRequest helpRequest = db.helpRequests.Find(id);
            if (helpRequest == null)
            {
                return HttpNotFound();
            }
            return View(helpRequest);
        }

        // POST: helpRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            helpRequest helpRequest = db.helpRequests.Find(id);
            db.helpRequests.Remove(helpRequest);
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
