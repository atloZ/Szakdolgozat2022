using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NevezesAPI.Data;
using NevezesAPI.Models;

namespace NevezesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KorcsoportController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public KorcsoportController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Korcsoport
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Korcsoport>>> GetKorcsoports()
        {
            return await _context.Korcsoports.ToListAsync();
        }

        // GET: api/Korcsoport/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Korcsoport>> GetKorcsoport(int id)
        {
            var korcsoport = await _context.Korcsoports.FindAsync(id);

            if (korcsoport == null)
            {
                return NotFound();
            }

            return korcsoport;
        }

        // PUT: api/Korcsoport/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKorcsoport(int id, Korcsoport korcsoport)
        {
            if (id != korcsoport.Azon)
            {
                return BadRequest();
            }

            _context.Entry(korcsoport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KorcsoportExists(id))
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

        // POST: api/Korcsoport
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Korcsoport>> PostKorcsoport(Korcsoport korcsoport)
        {
            _context.Korcsoports.Add(korcsoport);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (KorcsoportExists(korcsoport.Azon))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetKorcsoport", new { id = korcsoport.Azon }, korcsoport);
        }

        // DELETE: api/Korcsoport/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKorcsoport(int id)
        {
            var korcsoport = await _context.Korcsoports.FindAsync(id);
            if (korcsoport == null)
            {
                return NotFound();
            }

            _context.Korcsoports.Remove(korcsoport);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KorcsoportExists(int id)
        {
            return _context.Korcsoports.Any(e => e.Azon == id);
        }
    }
}