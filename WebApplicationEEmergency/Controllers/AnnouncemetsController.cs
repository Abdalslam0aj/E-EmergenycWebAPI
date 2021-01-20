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
    public class AnnouncemetsController : Controller
    {
        private EEmergencyDataBaseEntities db = new EEmergencyDataBaseEntities();

        // GET: Announcemets
        public ActionResult Index()
        {
            return View(db.Announcemets.ToList());
        }

        // GET: Announcemets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Announcemet announcemet = db.Announcemets.Find(id);
            if (announcemet == null)
            {
                return HttpNotFound();
            }
            return View(announcemet);
        }

        // GET: Announcemets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Announcemets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,title,readMore")] Announcemet announcemet)
        {
            if (ModelState.IsValid)
            {
                db.Announcemets.Add(announcemet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(announcemet);
        }

        // GET: Announcemets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Announcemet announcemet = db.Announcemets.Find(id);
            if (announcemet == null)
            {
                return HttpNotFound();
            }
            return View(announcemet);
        }

        // POST: Announcemets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,title,readMore")] Announcemet announcemet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(announcemet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(announcemet);
        }

        // GET: Announcemets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Announcemet announcemet = db.Announcemets.Find(id);
            if (announcemet == null)
            {
                return HttpNotFound();
            }
            return View(announcemet);
        }

        // POST: Announcemets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Announcemet announcemet = db.Announcemets.Find(id);
            db.Announcemets.Remove(announcemet);
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
