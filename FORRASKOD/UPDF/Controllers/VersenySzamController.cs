#nullable disable

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UPDF.Data;
using UPDF.Models;

namespace UPDF.Controllers
{
    public class VersenySzamController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VersenySzamController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: VersenySzam
        public async Task<IActionResult> Index()
        {
            return View(await _context.VersenySzamok.ToListAsync());
        }

        // GET: VersenySzam/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var versenySzam = await _context.VersenySzamok
                .FirstOrDefaultAsync(m => m.Azon == id);
            if (versenySzam == null)
            {
                return NotFound();
            }

            return View(versenySzam);
        }

        // GET: VersenySzam/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VersenySzam/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Azon,Megnevezes,Letszam")] VersenySzam versenySzam)
        {
            if (ModelState.IsValid)
            {
                _context.Add(versenySzam);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(versenySzam);
        }

        // GET: VersenySzam/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var versenySzam = await _context.VersenySzamok.FindAsync(id);
            if (versenySzam == null)
            {
                return NotFound();
            }
            return View(versenySzam);
        }

        // POST: VersenySzam/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Azon,Megnevezes,Letszam")] VersenySzam versenySzam)
        {
            if (id != versenySzam.Azon)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(versenySzam);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VersenySzamExists(versenySzam.Azon))
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
            return View(versenySzam);
        }

        // GET: VersenySzam/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var versenySzam = await _context.VersenySzamok
                .FirstOrDefaultAsync(m => m.Azon == id);
            if (versenySzam == null)
            {
                return NotFound();
            }

            return View(versenySzam);
        }

        // POST: VersenySzam/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var versenySzam = await _context.VersenySzamok.FindAsync(id);
            _context.VersenySzamok.Remove(versenySzam);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VersenySzamExists(int id)
        {
            return _context.VersenySzamok.Any(e => e.Azon == id);
        }
    }
}