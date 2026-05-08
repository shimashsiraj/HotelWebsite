using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Saint.Data;
using Saint.Models;

namespace Saint.Controllers
{
    public class HotelPoliciesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HotelPoliciesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HotelPolicies
        public async Task<IActionResult> Index()
        {
            return View(await _context.HotelPolicies.ToListAsync());
        }

        // GET: HotelPolicies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelPolicy = await _context.HotelPolicies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hotelPolicy == null)
            {
                return NotFound();
            }

            return View();
        }

        // GET: HotelPolicies/Create
        public IActionResult Create()
        {

            return View();
        }

        // POST: HotelPolicies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,LastUpdated")] HotelPolicy hotelPolicy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hotelPolicy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["ShowNavbar"] = true;

            return View(hotelPolicy);
        }

        // GET: HotelPolicies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelPolicy = await _context.HotelPolicies.FindAsync(id);
            if (hotelPolicy == null)
            {
                return NotFound();
            }

            return View(hotelPolicy);
        }

        // POST: HotelPolicies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,LastUpdated")] HotelPolicy hotelPolicy)
        {
            if (id != hotelPolicy.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotelPolicy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelPolicyExists(hotelPolicy.Id))
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
            return View(hotelPolicy);
        }

        // GET: HotelPolicies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelPolicy = await _context.HotelPolicies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hotelPolicy == null)
            {
                return NotFound();
            }

            return View(hotelPolicy);
        }

        // POST: HotelPolicies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hotelPolicy = await _context.HotelPolicies.FindAsync(id);
            if (hotelPolicy != null)
            {
                _context.HotelPolicies.Remove(hotelPolicy);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HotelPolicyExists(int id)
        {
            return _context.HotelPolicies.Any(e => e.Id == id);
        }
    }
}
