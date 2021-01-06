using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EEmergencyWebApi.Controllers
{
    public class DCDADD : Controller
    {
        // GET: DCDADD
        public ActionResult Index()
        {
            return View();
        }

        // GET: DCDADD/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DCDADD/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DCDADD/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DCDADD/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DCDADD/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DCDADD/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DCDADD/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
