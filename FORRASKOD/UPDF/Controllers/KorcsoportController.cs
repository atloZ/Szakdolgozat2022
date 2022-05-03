#nullable disable

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UPDF.Data;
using UPDF.Models;

namespace UPDF.Controllers
{
    public class KorcsoportController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KorcsoportController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Korcsoport
        public async Task<IActionResult> Index()
        {
            return View(await _context.Korcsoportok.ToListAsync());
        }

        // GET: Korcsoport/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var korcsoport = await _context.Korcsoportok
                .FirstOrDefaultAsync(m => m.Azon == id);
            if (korcsoport == null)
            {
                return NotFound();
            }

            return View(korcsoport);
        }

        // GET: Korcsoport/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Korcsoport/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Azon,Megnevezes,Minimum,Maximum")] Korcsoport korcsoport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(korcsoport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(korcsoport);
        }

        // GET: Korcsoport/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var korcsoport = await _context.Korcsoportok.FindAsync(id);
            if (korcsoport == null)
            {
                return NotFound();
            }
            return View(korcsoport);
        }

        // POST: Korcsoport/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Azon,Megnevezes,Minimum,Maximum")] Korcsoport korcsoport)
        {
            if (id != korcsoport.Azon)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(korcsoport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KorcsoportExists(korcsoport.Azon))
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
            return View(korcsoport);
        }

        // GET: Korcsoport/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var korcsoport = await _context.Korcsoportok
                .FirstOrDefaultAsync(m => m.Azon == id);
            if (korcsoport == null)
            {
                return NotFound();
            }

            return View(korcsoport);
        }

        // POST: Korcsoport/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var korcsoport = await _context.Korcsoportok.FindAsync(id);
            _context.Korcsoportok.Remove(korcsoport);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KorcsoportExists(int id)
        {
            return _context.Korcsoportok.Any(e => e.Azon == id);
        }
    }
}