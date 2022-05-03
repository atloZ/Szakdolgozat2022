#nullable disable

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UPDF.Data;
using UPDF.Models;

namespace UPDF.Controllers
{
    [Authorize(Roles = "Admin, User")]
    public class EgyesuletController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EgyesuletController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Egyesulet
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Egyesuletek.ToListAsync());
        }

        // GET: Egyesulet/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var egyesulet = await _context.Egyesuletek
                .FirstOrDefaultAsync(m => m.Azon == id);
            if (egyesulet == null)
            {
                return NotFound();
            }

            return View(egyesulet);
        }

        // GET: Egyesulet/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Egyesulet/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Azon,Nev,Rovidites")] Egyesulet egyesulet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(egyesulet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(egyesulet);
        }

        // GET: Egyesulet/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var egyesulet = await _context.Egyesuletek.FindAsync(id);
            if (egyesulet == null)
            {
                return NotFound();
            }
            return View(egyesulet);
        }

        // POST: Egyesulet/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Azon,Nev,Rovidites")] Egyesulet egyesulet)
        {
            if (id != egyesulet.Azon)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(egyesulet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EgyesuletExists(egyesulet.Azon))
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
            return View(egyesulet);
        }

        // GET: Egyesulet/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var egyesulet = await _context.Egyesuletek
                .FirstOrDefaultAsync(m => m.Azon == id);
            if (egyesulet == null)
            {
                return NotFound();
            }

            return View(egyesulet);
        }

        // POST: Egyesulet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var egyesulet = await _context.Egyesuletek.FindAsync(id);
            _context.Egyesuletek.Remove(egyesulet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EgyesuletExists(int id)
        {
            return _context.Egyesuletek.Any(e => e.Azon == id);
        }
    }
}