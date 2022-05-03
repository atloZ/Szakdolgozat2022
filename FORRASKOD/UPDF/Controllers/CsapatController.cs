#nullable disable

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UPDF.Data;
using UPDF.Models;

namespace UPDF.Controllers
{
    public class CsapatController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CsapatController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Csapat
        public async Task<IActionResult> Index()
        {
            return View(await _context.Csapatok.ToListAsync());
        }

        // GET: Csapat/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var csapat = await _context.Csapatok
                .FirstOrDefaultAsync(m => m.Azon == id);
            if (csapat == null)
            {
                return NotFound();
            }

            return View(csapat);
        }

        // GET: Csapat/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Csapat/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Azon")] Csapat csapat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(csapat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(csapat);
        }

        // GET: Csapat/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var csapat = await _context.Csapatok.FindAsync(id);
            if (csapat == null)
            {
                return NotFound();
            }
            return View(csapat);
        }

        // POST: Csapat/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Azon")] Csapat csapat)
        {
            if (id != csapat.Azon)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(csapat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CsapatExists(csapat.Azon))
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
            return View(csapat);
        }

        // GET: Csapat/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var csapat = await _context.Csapatok
                .FirstOrDefaultAsync(m => m.Azon == id);
            if (csapat == null)
            {
                return NotFound();
            }

            return View(csapat);
        }

        // POST: Csapat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var csapat = await _context.Csapatok.FindAsync(id);
            _context.Csapatok.Remove(csapat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CsapatExists(int id)
        {
            return _context.Csapatok.Any(e => e.Azon == id);
        }
    }
}