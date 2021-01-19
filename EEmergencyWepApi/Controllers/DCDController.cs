using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EEmergencyWebApi.Controllers
{
    public class DCDController : Controller
    {
        // GET: DCDController
        public ActionResult Index()
        {
            return View();
        }

        // GET: DCDController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DCDController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DCDController/Create
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

        // GET: DCDController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DCDController/Edit/5
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

        // GET: DCDController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DCDController/Delete/5
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
