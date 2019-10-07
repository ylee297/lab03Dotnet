using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using lab03.Data;

namespace lab03.Controllers
{
    public class ProvincesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProvincesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Provinces
        public async Task<IActionResult> Index()
        {
            return View(await _context.Provinces.ToListAsync());
        }

        // GET: Provinces/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var province = await _context.Provinces
                .FirstOrDefaultAsync(m => m.ProvinceCode == id);
            if (province == null)
            {
                return NotFound();
            }

            return View(province);
        }

        // GET: Provinces/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Provinces/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProvinceCode,ProvinceName")] Province province)
        {
            if (ModelState.IsValid)
            {
                _context.Add(province);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(province);
        }

        // GET: Provinces/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var province = await _context.Provinces.FindAsync(id);
            if (province == null)
            {
                return NotFound();
            }
            return View(province);
        }

        // POST: Provinces/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ProvinceCode,ProvinceName")] Province province)
        {
            if (id != province.ProvinceCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(province);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProvinceExists(province.ProvinceCode))
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
            return View(province);
        }

        // GET: Provinces/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var province = await _context.Provinces
                .FirstOrDefaultAsync(m => m.ProvinceCode == id);
            if (province == null)
            {
                return NotFound();
            }

            return View(province);
        }

        // POST: Provinces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var province = await _context.Provinces.FindAsync(id);
            _context.Provinces.Remove(province);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProvinceExists(string id)
        {
            return _context.Provinces.Any(e => e.ProvinceCode == id);
        }
    }
}
