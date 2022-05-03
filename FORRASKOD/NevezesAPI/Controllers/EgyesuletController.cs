using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NevezesAPI.Data;
using NevezesAPI.Models;

namespace NevezesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EgyesuletController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EgyesuletController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Egyesulet
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Egyesulet>>> GetEgyesulets()
        {
            return await _context.Egyesulets.ToListAsync();
        }

        // GET: api/Egyesulet/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Egyesulet>> GetEgyesulet(int id)
        {
            var egyesulet = await _context.Egyesulets.FindAsync(id);

            if (egyesulet == null)
            {
                return NotFound();
            }

            return egyesulet;
        }

        // PUT: api/Egyesulet/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEgyesulet(int id, Egyesulet egyesulet)
        {
            if (id != egyesulet.Azon)
            {
                return BadRequest();
            }

            _context.Entry(egyesulet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EgyesuletExists(id))
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

        // POST: api/Egyesulet
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Egyesulet>> PostEgyesulet(Egyesulet egyesulet)
        {
            _context.Egyesulets.Add(egyesulet);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EgyesuletExists(egyesulet.Azon))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEgyesulet", new { id = egyesulet.Azon }, egyesulet);
        }

        // DELETE: api/Egyesulet/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEgyesulet(int id)
        {
            var egyesulet = await _context.Egyesulets.FindAsync(id);
            if (egyesulet == null)
            {
                return NotFound();
            }

            _context.Egyesulets.Remove(egyesulet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EgyesuletExists(int id)
        {
            return _context.Egyesulets.Any(e => e.Azon == id);
        }
    }
}