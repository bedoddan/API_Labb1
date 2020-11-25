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
    public class FiskController : ControllerBase
    {
        private readonly Context _context;

        public FiskController(Context context)
        {
            _context = context;
        }


        // GET: api/Fisk
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fiskmodell>>> GetFiskar()
        {
            return await _context.Fiskar.ToListAsync();
        }

        // GET: api/Fisk/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fiskmodell>> GetFiskmodell(int id)
        {
            var fiskmodell = await _context.Fiskar.FindAsync(id);
            

            if (fiskmodell == null)
            {
                return NotFound();
            }

            return fiskmodell;
        }


        // PUT: api/Fisk/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFiskmodell(int id, Fiskmodell fiskmodell)
        {
            if (id != fiskmodell.FiskID)
            {
                return BadRequest();
            }

            _context.Entry(fiskmodell).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FiskmodellExists(id))
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

        // POST: api/Fisk
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Fiskmodell>> PostFiskmodell(Fiskmodell fiskmodell)
        {
            _context.Fiskar.Add(fiskmodell);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFiskmodell", new { id = fiskmodell.FiskID }, fiskmodell);
        }

        // DELETE: api/Fisk/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Fiskmodell>> DeleteFiskmodell(int id)
        {
            var fiskmodell = await _context.Fiskar.FindAsync(id);
            if (fiskmodell == null)
            {
                return NotFound();
            }

            _context.Fiskar.Remove(fiskmodell);
            await _context.SaveChangesAsync();

            return fiskmodell;
        }

        private bool FiskmodellExists(int id)
        {
            return _context.Fiskar.Any(e => e.FiskID == id);
        }
    }
}
