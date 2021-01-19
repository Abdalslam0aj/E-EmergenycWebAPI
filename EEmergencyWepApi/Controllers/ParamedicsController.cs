using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EEmergencyWepApi.Data.module;
using EEmergencyWepApi.Models;

namespace EEmergencyWebApi.Controllers
{
    [Route("[controller]")]
    public class ParamedicsController : Controller
    {
        private readonly ConctionDbClass _context;

        public ParamedicsController(ConctionDbClass context)
        {
            _context = context;
        }

        // GET: Paramedics
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Paramedic.ToListAsync());
        }

        // GET: Paramedics/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paramedic = await _context.Paramedic
                .FirstOrDefaultAsync(m => m.phoneNumber == id);
            if (paramedic == null)
            {
                return NotFound();
            }

            return View(paramedic);
        }

        // GET: Paramedics/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Paramedics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("phoneNumber,password,NIDN,fullName,status,notificationToken,team")] Paramedic paramedic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paramedic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paramedic);
        }

        // GET: Paramedics/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paramedic = await _context.Paramedic.FindAsync(id);
            if (paramedic == null)
            {
                return NotFound();
            }
            return View(paramedic);
        }

        // POST: Paramedics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("phoneNumber,password,NIDN,fullName,status,notificationToken,team")] Paramedic paramedic)
        {
            if (id != paramedic.phoneNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paramedic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParamedicExists(paramedic.phoneNumber))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(paramedic);
        }

        // GET: Paramedics/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paramedic = await _context.Paramedic
                .FirstOrDefaultAsync(m => m.phoneNumber == id);
            if (paramedic == null)
            {
                return NotFound();
            }

            return View(paramedic);
        }

        // POST: Paramedics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var paramedic = await _context.Paramedic.FindAsync(id);
            _context.Paramedic.Remove(paramedic);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParamedicExists(string id)
        {
            return _context.Paramedic.Any(e => e.phoneNumber == id);
        }
    }
}
