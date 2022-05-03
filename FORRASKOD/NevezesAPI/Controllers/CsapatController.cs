using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NevezesAPI.Data;
using NevezesAPI.Models;

namespace NevezesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CsapatController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CsapatController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Csapat
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Csapat>>> GetCsapats()
        {
            return await _context.Csapats.ToListAsync();
        }

        // GET: api/Csapat/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Csapat>> GetCsapat(int id)
        {
            var csapat = await _context.Csapats.FindAsync(id);

            if (csapat == null)
            {
                return NotFound();
            }

            return csapat;
        }

        // PUT: api/Csapat/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCsapat(int id, Csapat csapat)
        {
            if (id != csapat.Azon)
            {
                return BadRequest();
            }

            _context.Entry(csapat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CsapatExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Csapat
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Csapat>> PostCsapat(Csapat csapat)
        {
            _context.Csapats.Add(csapat);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CsapatExists(csapat.Azon))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCsapat", new { id = csapat.Azon }, csapat);
        }

        // DELETE: api/Csapat/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCsapat(int id)
        {
            var csapat = await _context.Csapats.FindAsync(id);
            if (csapat == null)
            {
                return NotFound();
            }

            _context.Csapats.Remove(csapat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CsapatExists(int id)
        {
            return _context.Csapats.Any(e => e.Azon == id);
        }
    }
}