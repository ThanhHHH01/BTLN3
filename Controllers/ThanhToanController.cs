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
    public class ThanhToanController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ThanhToanController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ThanhToan
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ThanhToan.Include(t => t.GoiTap).Include(t => t.HoiVien).Include(t => t.TinhTrang);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ThanhToan/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.ThanhToan == null)
            {
                return NotFound();
            }

            var thanhToan = await _context.ThanhToan
                .Include(t => t.GoiTap)
                .Include(t => t.HoiVien)
                .Include(t => t.TinhTrang)
                .FirstOrDefaultAsync(m => m.MaHD == id);
            if (thanhToan == null)
            {
                return NotFound();
            }

            return View(thanhToan);
        }

        // GET: ThanhToan/Create
        public IActionResult Create()
        {
            ViewData["MaGoiTap"] = new SelectList(_context.GoiTap, "MaGoiTap", "MaGoiTap");
            ViewData["HoiVienID"] = new SelectList(_context.HoiVien, "HoiVienID", "HoiVienID");
            ViewData["MaTinhTrang"] = new SelectList(_context.Set<TinhTrang>(), "MaTinhTrang", "MaTinhTrang");
            return View();
        }

        // POST: ThanhToan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaHD,HoiVienID,MaGoiTap,Ngayban,MaTinhTrang")] ThanhToan thanhToan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(thanhToan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaGoiTap"] = new SelectList(_context.GoiTap, "MaGoiTap", "MaGoiTap", thanhToan.MaGoiTap);
            ViewData["HoiVienID"] = new SelectList(_context.HoiVien, "HoiVienID", "HoiVienID", thanhToan.HoiVienID);
            ViewData["MaTinhTrang"] = new SelectList(_context.Set<TinhTrang>(), "MaTinhTrang", "MaTinhTrang", thanhToan.MaTinhTrang);
            return View(thanhToan);
        }

        // GET: ThanhToan/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.ThanhToan == null)
            {
                return NotFound();
            }

            var thanhToan = await _context.ThanhToan.FindAsync(id);
            if (thanhToan == null)
            {
                return NotFound();
            }
            ViewData["MaGoiTap"] = new SelectList(_context.GoiTap, "MaGoiTap", "MaGoiTap", thanhToan.MaGoiTap);
            ViewData["HoiVienID"] = new SelectList(_context.HoiVien, "HoiVienID", "HoiVienID", thanhToan.HoiVienID);
            ViewData["MaTinhTrang"] = new SelectList(_context.Set<TinhTrang>(), "MaTinhTrang", "MaTinhTrang", thanhToan.MaTinhTrang);
            return View(thanhToan);
        }

        // POST: ThanhToan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaHD,HoiVienID,MaGoiTap,Ngayban,MaTinhTrang")] ThanhToan thanhToan)
        {
            if (id != thanhToan.MaHD)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(thanhToan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThanhToanExists(thanhToan.MaHD))
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
            ViewData["MaGoiTap"] = new SelectList(_context.GoiTap, "MaGoiTap", "MaGoiTap", thanhToan.MaGoiTap);
            ViewData["HoiVienID"] = new SelectList(_context.HoiVien, "HoiVienID", "HoiVienID", thanhToan.HoiVienID);
            ViewData["MaTinhTrang"] = new SelectList(_context.Set<TinhTrang>(), "MaTinhTrang", "MaTinhTrang", thanhToan.MaTinhTrang);
            return View(thanhToan);
        }

        // GET: ThanhToan/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.ThanhToan == null)
            {
                return NotFound();
            }

            var thanhToan = await _context.ThanhToan
                .Include(t => t.GoiTap)
                .Include(t => t.HoiVien)
                .Include(t => t.TinhTrang)
                .FirstOrDefaultAsync(m => m.MaHD == id);
            if (thanhToan == null)
            {
                return NotFound();
            }

            return View(thanhToan);
        }

        // POST: ThanhToan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.ThanhToan == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ThanhToan'  is null.");
            }
            var thanhToan = await _context.ThanhToan.FindAsync(id);
            if (thanhToan != null)
            {
                _context.ThanhToan.Remove(thanhToan);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThanhToanExists(string id)
        {
          return (_context.ThanhToan?.Any(e => e.MaHD == id)).GetValueOrDefault();
        }
    }
}
