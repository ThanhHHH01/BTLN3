using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BTLN3.Models;
using BTLN3.Models.Process;

namespace BTLN3.Controllers
{
    public class ChucVuController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChucVuController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ChucVu
        public async Task<IActionResult> Index()
        {
              return _context.ChucVu != null ? 
                          View(await _context.ChucVu.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.ChucVu'  is null.");
        }

        // GET: ChucVu/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.ChucVu == null)
            {
                return NotFound();
            }

            var chucVu = await _context.ChucVu
                .FirstOrDefaultAsync(m => m.MaChucVu == id);
            if (chucVu == null)
            {
                return NotFound();
            }

            return View(chucVu);
        }

        // GET: ChucVu/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ChucVu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaChucVu,TenChucVu")] ChucVu chucVu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chucVu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chucVu);
        }

        // GET: ChucVu/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.ChucVu == null)
            {
                return NotFound();
            }

            var chucVu = await _context.ChucVu.FindAsync(id);
            if (chucVu == null)
            {
                return NotFound();
            }
            return View(chucVu);
        }

        // POST: ChucVu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaChucVu,TenChucVu")] ChucVu chucVu)
        {
            if (id != chucVu.MaChucVu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chucVu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChucVuExists(chucVu.MaChucVu))
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
            return View(chucVu);
        }

        // GET: ChucVu/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.ChucVu == null)
            {
                return NotFound();
            }

            var chucVu = await _context.ChucVu
                .FirstOrDefaultAsync(m => m.MaChucVu == id);
            if (chucVu == null)
            {
                return NotFound();
            }

            return View(chucVu);
        }

        // POST: ChucVu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.ChucVu == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ChucVu'  is null.");
            }
            var chucVu = await _context.ChucVu.FindAsync(id);
            if (chucVu != null)
            {
                _context.ChucVu.Remove(chucVu);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChucVuExists(string id)
        {
          return (_context.ChucVu?.Any(e => e.MaChucVu == id)).GetValueOrDefault();
        }
        //upload
        private ExcelProcess _excelProcess = new ExcelProcess();

        public async Task<IActionResult> Upload()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Upload(IFormFile file)
        {
            if (file!=null)
            {
                string fileExtension = Path.GetExtension(file.FileName);
                if (fileExtension != ".xls" && fileExtension != ".xlsx")
                {
                    ModelState.AddModelError("", "Please choose excel file to upload!");
                }
                else
                {
                    //rename file when upload to sever
                    var fileName = DateTime.Now.ToShortTimeString() + fileExtension;
                    var filePath = Path.Combine(Directory.GetCurrentDirectory() + "/Uploads/Excels", fileName);
                    var fileLocation = new FileInfo(filePath).ToString();
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        //save file to server
                        await file.CopyToAsync(stream);
                        //read data from file and write to database
                        var dt = _excelProcess.ExcelToDataTable(fileLocation);
                        //dùng vòng lặp for để đọc dữ liệu dạng hd
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            //create a new Student object
                            var hd = new ChucVu();
                            //set values for attribiutes
                            hd.MaChucVu = dt.Rows[i][0].ToString();
                            hd.TenChucVu = dt.Rows[i][1].ToString();
                            //add oject to context
                            _context.ChucVu.Add(hd);
                        }
                        //save to database
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            return View();
    }
}
}