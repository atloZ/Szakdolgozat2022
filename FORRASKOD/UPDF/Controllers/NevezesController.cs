#nullable disable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UPDF.Data;
using UPDF.Models;

namespace UPDF.Controllers
{
    public class NevezesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NevezesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Nevezes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Nevezesek.Include(n => n.CsapatAzonNavigation).Include(n => n.KategoriaAzonNavigation).Include(n => n.KorcsoportAzonNavigation).Include(n => n.RogzitoAzonNavigation).Include(n => n.VersenySzamAzonNavigation).Include(n => n.VersenyzoAzonNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Nevezes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nevezes = await _context.Nevezesek
                .Include(n => n.CsapatAzonNavigation)
                .Include(n => n.KategoriaAzonNavigation)
                .Include(n => n.KorcsoportAzonNavigation)
                .Include(n => n.RogzitoAzonNavigation)
                .Include(n => n.VersenySzamAzonNavigation)
                .Include(n => n.VersenyzoAzonNavigation)
                .FirstOrDefaultAsync(m => m.Azon == id);
            if (nevezes == null)
            {
                return NotFound();
            }

            return View(nevezes);
        }

        // GET: Nevezes/Create
        public IActionResult Create()
        {
            ViewData["CsapatAzon"] = new SelectList(_context.Csapatok, "Azon", "Azon");
            ViewData["KategoriaAzon"] = new SelectList(_context.Kategoriak, "Azon", "Azon");
            ViewData["KorcsoportAzon"] = new SelectList(_context.Korcsoportok, "Azon", "Azon");
            ViewData["VersenySzamAzon"] = new SelectList(_context.VersenySzamok, "Azon", "Azon");
            ViewData["VersenyzoAzon"] = new SelectList(_context.Versenyzok, "SirAzon", "SirAzon");
            return View();
        }

        // POST: Nevezes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Azon,KoreoCim,VersenyzoAzon,KorcsoportAzon,KategoriaAzon,VersenySzamAzon,CsapatAzon,ZenePath,RogzitoAzon")] Nevezes nevezes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nevezes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CsapatAzon"] = new SelectList(_context.Csapatok, "Azon", "Azon", nevezes.CsapatAzon);
            ViewData["KategoriaAzon"] = new SelectList(_context.Kategoriak, "Azon", "Azon", nevezes.KategoriaAzon);
            ViewData["KorcsoportAzon"] = new SelectList(_context.Korcsoportok, "Azon", "Azon", nevezes.KorcsoportAzon);
            ViewData["VersenySzamAzon"] = new SelectList(_context.VersenySzamok, "Azon", "Azon", nevezes.VersenySzamAzon);
            ViewData["VersenyzoAzon"] = new SelectList(_context.Versenyzok, "SirAzon", "SirAzon", nevezes.VersenyzoAzon);
            return View(nevezes);
        }

        // GET: Nevezes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nevezes = await _context.Nevezesek.FindAsync(id);
            if (nevezes == null)
            {
                return NotFound();
            }
            ViewData["CsapatAzon"] = new SelectList(_context.Csapatok, "Azon", "Azon", nevezes.CsapatAzon);
            ViewData["KategoriaAzon"] = new SelectList(_context.Kategoriak, "Azon", "Azon", nevezes.KategoriaAzon);
            ViewData["KorcsoportAzon"] = new SelectList(_context.Korcsoportok, "Azon", "Azon", nevezes.KorcsoportAzon);
            ViewData["VersenySzamAzon"] = new SelectList(_context.VersenySzamok, "Azon", "Azon", nevezes.VersenySzamAzon);
            ViewData["VersenyzoAzon"] = new SelectList(_context.Versenyzok, "SirAzon", "SirAzon", nevezes.VersenyzoAzon);
            return View(nevezes);
        }

        // POST: Nevezes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Azon,KoreoCim,VersenyzoAzon,KorcsoportAzon,KategoriaAzon,VersenySzamAzon,CsapatAzon,ZenePath,RogzitoAzon")] Nevezes nevezes)
        {
            if (id != nevezes.Azon)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nevezes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NevezesExists(nevezes.Azon))
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
            ViewData["CsapatAzon"] = new SelectList(_context.Csapatok, "Azon", "Azon", nevezes.CsapatAzon);
            ViewData["KategoriaAzon"] = new SelectList(_context.Kategoriak, "Azon", "Azon", nevezes.KategoriaAzon);
            ViewData["KorcsoportAzon"] = new SelectList(_context.Korcsoportok, "Azon", "Azon", nevezes.KorcsoportAzon);
            ViewData["VersenySzamAzon"] = new SelectList(_context.VersenySzamok, "Azon", "Azon", nevezes.VersenySzamAzon);
            ViewData["VersenyzoAzon"] = new SelectList(_context.Versenyzok, "SirAzon", "SirAzon", nevezes.VersenyzoAzon);
            return View(nevezes);
        }

        // GET: Nevezes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nevezes = await _context.Nevezesek
                .Include(n => n.CsapatAzonNavigation)
                .Include(n => n.KategoriaAzonNavigation)
                .Include(n => n.KorcsoportAzonNavigation)
                .Include(n => n.RogzitoAzonNavigation)
                .Include(n => n.VersenySzamAzonNavigation)
                .Include(n => n.VersenyzoAzonNavigation)
                .FirstOrDefaultAsync(m => m.Azon == id);
            if (nevezes == null)
            {
                return NotFound();
            }

            return View(nevezes);
        }

        // POST: Nevezes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nevezes = await _context.Nevezesek.FindAsync(id);
            _context.Nevezesek.Remove(nevezes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NevezesExists(int id)
        {
            return _context.Nevezesek.Any(e => e.Azon == id);
        }
    }
}