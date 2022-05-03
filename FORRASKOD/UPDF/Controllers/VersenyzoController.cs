#nullable disable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UPDF.Data;

namespace UPDF.Controllers.Versenyzo
{
    public class VersenyzoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VersenyzoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Versenyzo
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Versenyzok.Include(v => v.EgyesuletAzonNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Versenyzo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var versenyzo = await _context.Versenyzok
                .Include(v => v.EgyesuletAzonNavigation)
                .FirstOrDefaultAsync(m => m.SirAzon == id);
            if (versenyzo == null)
            {
                return NotFound();
            }

            return View(versenyzo);
        }

        // GET: Versenyzo/Create
        public IActionResult Create()
        {
            ViewData["EgyesuletAzon"] = new SelectList(_context.Egyesuletek, "Azon", "Azon");
            return View();
        }

        // POST: Versenyzo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SirAzon,EgyesuletAzon,Nev,SzulHely,SzulDatum,EngedelySzam,EngedelyErv")] UPDF.Models.Versenyzo versenyzo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(versenyzo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EgyesuletAzon"] = new SelectList(_context.Egyesuletek, "Azon", "Azon", versenyzo.EgyesuletAzon);
            return View(versenyzo);
        }

        // GET: Versenyzo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var versenyzo = await _context.Versenyzok.FindAsync(id);
            if (versenyzo == null)
            {
                return NotFound();
            }
            ViewData["EgyesuletAzon"] = new SelectList(_context.Egyesuletek, "Azon", "Azon", versenyzo.EgyesuletAzon);
            return View(versenyzo);
        }

        // POST: Versenyzo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SirAzon,EgyesuletAzon,Nev,SzulHely,SzulDatum,EngedelySzam,EngedelyErv")] UPDF.Models.Versenyzo versenyzo)
        {
            if (id != versenyzo.SirAzon)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(versenyzo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VersenyzoExists(versenyzo.SirAzon))
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
            ViewData["EgyesuletAzon"] = new SelectList(_context.Egyesuletek, "Azon", "Azon", versenyzo.EgyesuletAzon);
            return View(versenyzo);
        }

        // GET: Versenyzo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var versenyzo = await _context.Versenyzok
                .Include(v => v.EgyesuletAzonNavigation)
                .FirstOrDefaultAsync(m => m.SirAzon == id);
            if (versenyzo == null)
            {
                return NotFound();
            }

            return View(versenyzo);
        }

        // POST: Versenyzo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var versenyzo = await _context.Versenyzok.FindAsync(id);
            _context.Versenyzok.Remove(versenyzo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VersenyzoExists(int id)
        {
            return _context.Versenyzok.Any(e => e.SirAzon == id);
        }
    }
}