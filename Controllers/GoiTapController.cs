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
    public class GoiTapController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GoiTapController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GoiTap
        public async Task<IActionResult> Index()
        {
              return _context.GoiTap != null ? 
                          View(await _context.GoiTap.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.GoiTap'  is null.");
        }

        // GET: GoiTap/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.GoiTap == null)
            {
                return NotFound();
            }

            var goiTap = await _context.GoiTap
                .FirstOrDefaultAsync(m => m.MaGoiTap == id);
            if (goiTap == null)
            {
                return NotFound();
            }

            return View(goiTap);
        }

        // GET: GoiTap/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GoiTap/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaGoiTap,TenGoi,GiaGoi")] GoiTap goiTap)
        {
            if (ModelState.IsValid)
            {
                _context.Add(goiTap);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(goiTap);
        }

        // GET: GoiTap/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.GoiTap == null)
            {
                return NotFound();
            }

            var goiTap = await _context.GoiTap.FindAsync(id);
            if (goiTap == null)
            {
                return NotFound();
            }
            return View(goiTap);
        }

        // POST: GoiTap/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaGoiTap,TenGoi,GiaGoi")] GoiTap goiTap)
        {
            if (id != goiTap.MaGoiTap)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(goiTap);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GoiTapExists(goiTap.MaGoiTap))
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
            return View(goiTap);
        }

        // GET: GoiTap/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.GoiTap == null)
            {
                return NotFound();
            }

            var goiTap = await _context.GoiTap
                .FirstOrDefaultAsync(m => m.MaGoiTap == id);
            if (goiTap == null)
            {
                return NotFound();
            }

            return View(goiTap);
        }

        // POST: GoiTap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.GoiTap == null)
            {
                return Problem("Entity set 'ApplicationDbContext.GoiTap'  is null.");
            }
            var goiTap = await _context.GoiTap.FindAsync(id);
            if (goiTap != null)
            {
                _context.GoiTap.Remove(goiTap);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GoiTapExists(string id)
        {
          return (_context.GoiTap?.Any(e => e.MaGoiTap == id)).GetValueOrDefault();
        }
    }
}
