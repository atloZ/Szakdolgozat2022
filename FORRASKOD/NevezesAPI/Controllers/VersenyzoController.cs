using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NevezesAPI.Data;
using NevezesAPI.Models;

namespace NevezesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VersenyzoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VersenyzoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Versenyzo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Versenyzo>>> GetVersenyzos()
        {
            return await _context.Versenyzos.ToListAsync();
        }

        // GET: api/Versenyzo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Versenyzo>> GetVersenyzo(int id)
        {
            var versenyzo = await _context.Versenyzos.FindAsync(id);

            if (versenyzo == null)
            {
                return NotFound();
            }

            return versenyzo;
        }

        // PUT: api/Versenyzo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVersenyzo(int id, Versenyzo versenyzo)
        {
            if (id != versenyzo.SirAzon)
            {
                return BadRequest();
            }

            _context.Entry(versenyzo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VersenyzoExists(id))
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

        // POST: api/Versenyzo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Versenyzo>> PostVersenyzo(Versenyzo versenyzo)
        {
            _context.Versenyzos.Add(versenyzo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VersenyzoExists(versenyzo.SirAzon))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetVersenyzo", new { id = versenyzo.SirAzon }, versenyzo);
        }

        // DELETE: api/Versenyzo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVersenyzo(int id)
        {
            var versenyzo = await _context.Versenyzos.FindAsync(id);
            if (versenyzo == null)
            {
                return NotFound();
            }

            _context.Versenyzos.Remove(versenyzo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VersenyzoExists(int id)
        {
            return _context.Versenyzos.Any(e => e.SirAzon == id);
        }
    }
}