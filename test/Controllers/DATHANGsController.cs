using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using test.Data;
using test.Models;

namespace test.Controllers
{
    public class DATHANGsController : Controller
    {
        private readonly testContext _context;

        public DATHANGsController(testContext context)
        {
            _context = context;
        }

        // GET: DATHANGs
        public async Task<IActionResult> Index()
        {
            return View(await _context.DATHANG.ToListAsync());
        }

        // GET: DATHANGs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dATHANG = await _context.DATHANG
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dATHANG == null)
            {
                return NotFound();
            }

            return View(dATHANG);
        }

        // GET: DATHANGs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DATHANGs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,DATHANG_ID,NameOfCus,NameOfItem,NumberofItem,HowToPay,Address")] DATHANG dATHANG)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dATHANG);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dATHANG);
        }

        // GET: DATHANGs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dATHANG = await _context.DATHANG.FindAsync(id);
            if (dATHANG == null)
            {
                return NotFound();
            }
            return View(dATHANG);
        }

        // POST: DATHANGs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,DATHANG_ID,NameOfCus,NameOfItem,NumberofItem,HowToPay,Address")] DATHANG dATHANG)
        {
            if (id != dATHANG.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dATHANG);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DATHANGExists(dATHANG.ID))
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
            return View(dATHANG);
        }

        // GET: DATHANGs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dATHANG = await _context.DATHANG
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dATHANG == null)
            {
                return NotFound();
            }

            return View(dATHANG);
        }

        // POST: DATHANGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dATHANG = await _context.DATHANG.FindAsync(id);
            _context.DATHANG.Remove(dATHANG);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DATHANGExists(int id)
        {
            return _context.DATHANG.Any(e => e.ID == id);
        }
    }
}
