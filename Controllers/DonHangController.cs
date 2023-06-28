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
    public class DonHangController : Controller
    {
        private readonly BAITHI _context;

        public DonHangController(BAITHI context)
        {
            _context = context;
        }

        // GET: DonHang
        public async Task<IActionResult> Index()
        {
            var bAITHI = _context.DonHang.Include(d => d.KhachHang);
            return View(await bAITHI.ToListAsync());
        }

        // GET: DonHang/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.DonHang == null)
            {
                return NotFound();
            }

            var donHang = await _context.DonHang
                .Include(d => d.KhachHang)
                .FirstOrDefaultAsync(m => m.MaKhach == id);
            if (donHang == null)
            {
                return NotFound();
            }

            return View(donHang);
        }

        // GET: DonHang/Create
        public IActionResult Create()
        {
            ViewData["MaKhach"] = new SelectList(_context.KhachHang, "MaKhach", "MaKhach");
            return View();
        }

        // POST: DonHang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaKhach,MaDonHang,SoLuong")] DonHang donHang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(donHang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaKhach"] = new SelectList(_context.KhachHang, "MaKhach", "MaKhach", donHang.MaKhach);
            return View(donHang);
        }

        // GET: DonHang/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.DonHang == null)
            {
                return NotFound();
            }

            var donHang = await _context.DonHang.FindAsync(id);
            if (donHang == null)
            {
                return NotFound();
            }
            ViewData["MaKhach"] = new SelectList(_context.KhachHang, "MaKhach", "MaKhach", donHang.MaKhach);
            return View(donHang);
        }

        // POST: DonHang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaKhach,MaDonHang,SoLuong")] DonHang donHang)
        {
            if (id != donHang.MaKhach)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(donHang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonHangExists(donHang.MaKhach))
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
            ViewData["MaKhach"] = new SelectList(_context.KhachHang, "MaKhach", "MaKhach", donHang.MaKhach);
            return View(donHang);
        }

        // GET: DonHang/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.DonHang == null)
            {
                return NotFound();
            }

            var donHang = await _context.DonHang
                .Include(d => d.KhachHang)
                .FirstOrDefaultAsync(m => m.MaKhach == id);
            if (donHang == null)
            {
                return NotFound();
            }

            return View(donHang);
        }

        // POST: DonHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.DonHang == null)
            {
                return Problem("Entity set 'BAITHI.DonHang'  is null.");
            }
            var donHang = await _context.DonHang.FindAsync(id);
            if (donHang != null)
            {
                _context.DonHang.Remove(donHang);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DonHangExists(string id)
        {
          return (_context.DonHang?.Any(e => e.MaKhach == id)).GetValueOrDefault();
        }
    }
}
