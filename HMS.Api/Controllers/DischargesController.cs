using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HMS.Library.DAL;
using HMS.Library.Models;

namespace HMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DischargesController : ControllerBase
    {
        private readonly HMSdb _context;

        public DischargesController(HMSdb context)
        {
            _context = context;
        }

        // GET: api/Discharges
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Discharge>>> GetDischarges()
        {
            return await _context.Discharges.ToListAsync();
        }

        // GET: api/Discharges/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Discharge>> GetDischarge(int id)
        {
            var discharge = await _context.Discharges.FindAsync(id);

            if (discharge == null)
            {
                return NotFound();
            }

            return discharge;
        }

        // PUT: api/Discharges/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDischarge(int id, Discharge discharge)
        {
            if (id != discharge.DischargeId)
            {
                return BadRequest();
            }

            _context.Entry(discharge).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DischargeExists(id))
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

        // POST: api/Discharges
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Discharge>> PostDischarge(Discharge discharge)
        {
            _context.Discharges.Add(discharge);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDischarge", new { id = discharge.DischargeId }, discharge);
        }

        // DELETE: api/Discharges/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDischarge(int id)
        {
            var discharge = await _context.Discharges.FindAsync(id);
            if (discharge == null)
            {
                return NotFound();
            }

            _context.Discharges.Remove(discharge);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DischargeExists(int id)
        {
            return _context.Discharges.Any(e => e.DischargeId == id);
        }
    }
}
