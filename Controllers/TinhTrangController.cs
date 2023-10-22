using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BTLN3.Models;

namespace BTLN3.Controllers
{
    public class TinhTrangController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TinhTrangController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TinhTrang
        public async Task<IActionResult> Index()
        {
              return _context.TinhTrang != null ? 
                          View(await _context.TinhTrang.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.TinhTrang'  is null.");
        }

        // GET: TinhTrang/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.TinhTrang == null)
            {
                return NotFound();
            }

            var tinhTrang = await _context.TinhTrang
                .FirstOrDefaultAsync(m => m.MaTinhTrang == id);
            if (tinhTrang == null)
            {
                return NotFound();
            }

            return View(tinhTrang);
        }

        // GET: TinhTrang/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TinhTrang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaTinhTrang,TenND,NoidungTT")] TinhTrang tinhTrang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tinhTrang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tinhTrang);
        }

        // GET: TinhTrang/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.TinhTrang == null)
            {
                return NotFound();
            }

            var tinhTrang = await _context.TinhTrang.FindAsync(id);
            if (tinhTrang == null)
            {
                return NotFound();
            }
            return View(tinhTrang);
        }

        // POST: TinhTrang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaTinhTrang,TenND,NoidungTT")] TinhTrang tinhTrang)
        {
            if (id != tinhTrang.MaTinhTrang)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tinhTrang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TinhTrangExists(tinhTrang.MaTinhTrang))
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
            return View(tinhTrang);
        }

        // GET: TinhTrang/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.TinhTrang == null)
            {
                return NotFound();
            }

            var tinhTrang = await _context.TinhTrang
                .FirstOrDefaultAsync(m => m.MaTinhTrang == id);
            if (tinhTrang == null)
            {
                return NotFound();
            }

            return View(tinhTrang);
        }

        // POST: TinhTrang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.TinhTrang == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TinhTrang'  is null.");
            }
            var tinhTrang = await _context.TinhTrang.FindAsync(id);
            if (tinhTrang != null)
            {
                _context.TinhTrang.Remove(tinhTrang);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TinhTrangExists(string id)
        {
          return (_context.TinhTrang?.Any(e => e.MaTinhTrang == id)).GetValueOrDefault();
        }
    }
}
