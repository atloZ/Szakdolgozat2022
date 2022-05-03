using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NevezesAPI.Data;
using NevezesAPI.Models;

namespace NevezesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KategoriaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public KategoriaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Kategoria
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kategoria>>> GetKategoria()
        {
            return await _context.Kategoria.ToListAsync();
        }

        // GET: api/Kategoria/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kategoria>> GetKategoria(int id)
        {
            var kategoria = await _context.Kategoria.FindAsync(id);

            if (kategoria == null)
            {
                return NotFound();
            }

            return kategoria;
        }

        // PUT: api/Kategoria/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKategoria(int id, Kategoria kategoria)
        {
            if (id != kategoria.Azon)
            {
                return BadRequest();
            }

            _context.Entry(kategoria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KategoriaExists(id))
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

        // POST: api/Kategoria
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Kategoria>> PostKategoria(Kategoria kategoria)
        {
            _context.Kategoria.Add(kategoria);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (KategoriaExists(kategoria.Azon))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetKategoria", new { id = kategoria.Azon }, kategoria);
        }

        // DELETE: api/Kategoria/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKategoria(int id)
        {
            var kategoria = await _context.Kategoria.FindAsync(id);
            if (kategoria == null)
            {
                return NotFound();
            }

            _context.Kategoria.Remove(kategoria);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KategoriaExists(int id)
        {
            return _context.Kategoria.Any(e => e.Azon == id);
        }
    }
}