using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NevezesAPI.Data;
using NevezesAPI.Models;

namespace NevezesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NevezesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public NevezesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Nevezes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nevezes>>> GetNevezes()
        {
            return await _context.Nevezes.ToListAsync();
        }

        // GET: api/Nevezes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Nevezes>> GetNevezes(int id)
        {
            var nevezes = await _context.Nevezes.FindAsync(id);

            if (nevezes == null)
            {
                return NotFound();
            }

            return nevezes;
        }

        // PUT: api/Nevezes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNevezes(int id, Nevezes nevezes)
        {
            if (id != nevezes.Azon)
            {
                return BadRequest();
            }

            _context.Entry(nevezes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NevezesExists(id))
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

        // POST: api/Nevezes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Nevezes>> PostNevezes(Nevezes nevezes)
        {
            _context.Nevezes.Add(nevezes);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NevezesExists(nevezes.Azon))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetNevezes", new { id = nevezes.Azon }, nevezes);
        }

        // DELETE: api/Nevezes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNevezes(int id)
        {
            var nevezes = await _context.Nevezes.FindAsync(id);
            if (nevezes == null)
            {
                return NotFound();
            }

            _context.Nevezes.Remove(nevezes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NevezesExists(int id)
        {
            return _context.Nevezes.Any(e => e.Azon == id);
        }
    }
}