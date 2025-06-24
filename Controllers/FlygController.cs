using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FlygplatsApi.Models;

namespace FlygplatsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlygController : ControllerBase
    {
        private readonly Flygplatskontext _context;

        public FlygController(Flygplatskontext context)
        {
            _context = context;

            // Om det inte finns några flyg — lägg till ett exempel.
            if (_context.Flyg.Count() == 0)
            {
                _context.Flyg.Add(new Flyg
                {
                    Avgang = DateTime.Now,
                    Ankomst = DateTime.Now.AddHours(2),
                    Flygnummer = "AX123",
                    Flygbolag = "SAS",
                    Boarding = false
                });
                _context.SaveChanges();
            }
        }

        // GET: api/Flyg
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Flyg>>> GetFlyg()
        {
            return await _context.Flyg.ToListAsync();
        }

        // GET: api/Flyg/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Flyg>> GetFlyg(long id)
        {
            var flyg = await _context.Flyg.FindAsync(id);

            if (flyg == null)
            {
                return NotFound();
            }

            return flyg;
        }

        // POST: api/Flyg
        [HttpPost]
        public async Task<ActionResult<Flyg>> PostFlyg(Flyg flyg)
        {
            _context.Flyg.Add(flyg);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFlyg), new { id = flyg.Id }, flyg);
        }

        // PUT: api/Flyg/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlyg(long id, Flyg flyg)
        {
            if (id != flyg.Id)
            {
                return BadRequest();
            }

            _context.Entry(flyg).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Flyg.Any(e => e.Id == id))
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

        // DELETE: api/Flyg/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlyg(long id)
        {
            var flyg = await _context.Flyg.FindAsync(id);
            if (flyg == null)
            {
                return NotFound();
            }

            _context.Flyg.Remove(flyg);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
