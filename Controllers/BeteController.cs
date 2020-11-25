using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Labb1.Models;

namespace API_Labb1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeteController : ControllerBase
    {
        private readonly Context _context;

        public BeteController(Context context)
        {
            _context = context;
        }

        // GET: api/Bete
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Betesmodell>>> GetBeten()
        {
            return await _context.Beten.ToListAsync();
        }

        // GET: api/Bete/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Betesmodell>> GetBetesmodell(int id)
        {
            var betesmodell = await _context.Beten.FindAsync(id);

            if (betesmodell == null)
            {
                return NotFound();
            }

            return betesmodell;
        }

        // PUT: api/Bete/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBetesmodell(int id, Betesmodell betesmodell)
        {
            if (id != betesmodell.Betenr)
            {
                return BadRequest();
            }

            _context.Entry(betesmodell).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BetesmodellExists(id))
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

        // POST: api/Bete
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Betesmodell>> PostBetesmodell(Betesmodell betesmodell)
        {
            _context.Beten.Add(betesmodell);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBetesmodell", new { id = betesmodell.Betenr }, betesmodell);
        }

        // DELETE: api/Bete/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Betesmodell>> DeleteBetesmodell(int id)
        {
            var betesmodell = await _context.Beten.FindAsync(id);
            if (betesmodell == null)
            {
                return NotFound();
            }

            _context.Beten.Remove(betesmodell);
            await _context.SaveChangesAsync();

            return betesmodell;
        }

        private bool BetesmodellExists(int id)
        {
            return _context.Beten.Any(e => e.Betenr == id);
        }
    }
}
