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
    public class PersonController : ControllerBase
    {
        private readonly Context _context;

        public PersonController(Context context)
        {
            _context = context;
        }

        // GET: api/Person
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Personmodell>>> GetPersoner()
        {
            return await _context.Personer.ToListAsync();
        }

        // GET: api/Person/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Personmodell>> GetPersonmodell(long id)
        {
            var personmodell = await _context.Personer.FindAsync(id);

            if (personmodell == null)
            {
                return NotFound();
            }

            return personmodell;
        }

        // PUT: api/Person/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonmodell(long id, Personmodell personmodell)
        {
            if (id != personmodell.Persnr)
            {
                return BadRequest();
            }

            _context.Entry(personmodell).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonmodellExists(id))
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

        // POST: api/Person
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Personmodell>> PostPersonmodell(Personmodell personmodell)
        {
            _context.Personer.Add(personmodell);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonmodell", new { id = personmodell.Persnr }, personmodell);
        }

        // DELETE: api/Person/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Personmodell>> DeletePersonmodell(long id)
        {
            var personmodell = await _context.Personer.FindAsync(id);
            if (personmodell == null)
            {
                return NotFound();
            }

            _context.Personer.Remove(personmodell);
            await _context.SaveChangesAsync();

            return personmodell;
        }

        private bool PersonmodellExists(long id)
        {
            return _context.Personer.Any(e => e.Persnr == id);
        }
    }
}
