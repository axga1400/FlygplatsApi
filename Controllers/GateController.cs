using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FlygplatsApi.Models;

namespace FlygplatsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GateController : ControllerBase
    {
        private readonly Flygplatskontext _context;

        public GateController(Flygplatskontext context)
        {
            _context = context;

            // Om det inte finns några gates — lägg till ett exempel.
            if (_context.Gates.Count() == 0)
            {
                _context.Gates.Add(new Gate
                {
                    Namn = "Gate A1",
                    Terminal = "Terminal 1"
                });
                _context.SaveChanges();
            }
        }

        // GET: api/Gate
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gate>>> GetGates()
        {
            return await _context.Gates.ToListAsync();
        }

        // GET: api/Gate/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Gate>> GetGate(long id)
        {
            var gate = await _context.Gates.FindAsync(id);

            if (gate == null)
            {
                return NotFound();
            }

            return gate;
        }

        // POST: api/Gate
        [HttpPost]
        public async Task<ActionResult<Gate>> PostGate(Gate gate)
        {
            _context.Gates.Add(gate);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGate), new { id = gate.Id }, gate);
        }
    }
}