using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _2526_2221050281_BaiThi.Data;
using _2526_2221050281_BaiThi.Models;

namespace _2526_2221050281_BaiThi.Controllers
{
    public class PhuongXaController : Controller
    {
        private readonly AppDbContext _context;

        public PhuongXaController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.SinhVien.ToListAsync());
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phuongxa = await _context.SinhVien
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phuongxa == null)
            {
                return NotFound();
            }

            return View(phuongxa);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Age,Class")] PhuongXa phuongxa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phuongxa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(phuongxa);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phuongxa = await _context.SinhVien.FindAsync(id);
            if (phuongxa == null)
            {
                return NotFound();
            }
            return View(phuongxa);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Age,Class")] PhuongXa phuongxa)
        {
            if (id != phuongxa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phuongxa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhuongXaExists(phuongxa.Id))
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
            return View(phuongxa);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phuongxa = await _context.SinhVien
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phuongxa == null)
            {
                return NotFound();
            }

            return View(phuongxa);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phuongxa = await _context.SinhVien.FindAsync(id);
            if (phuongxa != null)
            {
                _context.SinhVien.Remove(phuongxa);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhuongXaExists(int id)
        {
            return _context.SinhVien.Any(e => e.Id == id);
        }
    }
}
