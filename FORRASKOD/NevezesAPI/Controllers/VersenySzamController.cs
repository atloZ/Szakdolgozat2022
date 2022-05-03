using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NevezesAPI.Data;
using NevezesAPI.Models;

namespace NevezesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VersenySzamController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VersenySzamController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/VersenySzam
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VersenySzam>>> GetVersenySzams()
        {
            return await _context.VersenySzams.ToListAsync();
        }

        // GET: api/VersenySzam/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VersenySzam>> GetVersenySzam(int id)
        {
            var versenySzam = await _context.VersenySzams.FindAsync(id);

            if (versenySzam == null)
            {
                return NotFound();
            }

            return versenySzam;
        }

        // PUT: api/VersenySzam/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVersenySzam(int id, VersenySzam versenySzam)
        {
            if (id != versenySzam.Azon)
            {
                return BadRequest();
            }

            _context.Entry(versenySzam).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VersenySzamExists(id))
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

        // POST: api/VersenySzam
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VersenySzam>> PostVersenySzam(VersenySzam versenySzam)
        {
            _context.VersenySzams.Add(versenySzam);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VersenySzamExists(versenySzam.Azon))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetVersenySzam", new { id = versenySzam.Azon }, versenySzam);
        }

        // DELETE: api/VersenySzam/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVersenySzam(int id)
        {
            var versenySzam = await _context.VersenySzams.FindAsync(id);
            if (versenySzam == null)
            {
                return NotFound();
            }

            _context.VersenySzams.Remove(versenySzam);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VersenySzamExists(int id)
        {
            return _context.VersenySzams.Any(e => e.Azon == id);
        }
    }
}