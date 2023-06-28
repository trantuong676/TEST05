using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TEST05.Models;

namespace TEST05.Controllers
{
    public class KhachHangController : Controller
    {
        private readonly BAITHI _context;

        public KhachHangController(BAITHI context)
        {
            _context = context;
        }

        // GET: KhachHang
        public async Task<IActionResult> Index()
        {
              return _context.KhachHang != null ? 
                          View(await _context.KhachHang.ToListAsync()) :
                          Problem("Entity set 'BAITHI.KhachHang'  is null.");
        }

        // GET: KhachHang/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.KhachHang == null)
            {
                return NotFound();
            }

            var khachHang = await _context.KhachHang
                .FirstOrDefaultAsync(m => m.MaKhach == id);
            if (khachHang == null)
            {
                return NotFound();
            }

            return View(khachHang);
        }

        // GET: KhachHang/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KhachHang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaKhach,TenKhachHang,GioiTinh")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(khachHang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(khachHang);
        }

        // GET: KhachHang/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.KhachHang == null)
            {
                return NotFound();
            }

            var khachHang = await _context.KhachHang.FindAsync(id);
            if (khachHang == null)
            {
                return NotFound();
            }
            return View(khachHang);
        }

        // POST: KhachHang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaKhach,TenKhachHang,GioiTinh")] KhachHang khachHang)
        {
            if (id != khachHang.MaKhach)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(khachHang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KhachHangExists(khachHang.MaKhach))
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
            return View(khachHang);
        }

        // GET: KhachHang/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.KhachHang == null)
            {
                return NotFound();
            }

            var khachHang = await _context.KhachHang
                .FirstOrDefaultAsync(m => m.MaKhach == id);
            if (khachHang == null)
            {
                return NotFound();
            }

            return View(khachHang);
        }

        // POST: KhachHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.KhachHang == null)
            {
                return Problem("Entity set 'BAITHI.KhachHang'  is null.");
            }
            var khachHang = await _context.KhachHang.FindAsync(id);
            if (khachHang != null)
            {
                _context.KhachHang.Remove(khachHang);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KhachHangExists(string id)
        {
          return (_context.KhachHang?.Any(e => e.MaKhach == id)).GetValueOrDefault();
        }
    }
}
