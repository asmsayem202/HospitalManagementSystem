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
    public class PrescribesController : ControllerBase
    {
        private readonly HMSdb _context;

        public PrescribesController(HMSdb context)
        {
            _context = context;
        }

        // GET: api/Prescribes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prescribe>>> GetPrescribes()
        {
            return await _context.Prescribes.ToListAsync();
        }

        // GET: api/Prescribes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Prescribe>> GetPrescribe(int id)
        {
            var prescribe = await _context.Prescribes.FindAsync(id);

            if (prescribe == null)
            {
                return NotFound();
            }

            return prescribe;
        }

        // PUT: api/Prescribes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrescribe(int id, Prescribe prescribe)
        {
            if (id != prescribe.PrescriptionId)
            {
                return BadRequest();
            }

            _context.Entry(prescribe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrescribeExists(id))
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

        // POST: api/Prescribes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Prescribe>> PostPrescribe(Prescribe prescribe)
        {
            _context.Prescribes.Add(prescribe);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrescribe", new { id = prescribe.PrescriptionId }, prescribe);
        }

        // DELETE: api/Prescribes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrescribe(int id)
        {
            var prescribe = await _context.Prescribes.FindAsync(id);
            if (prescribe == null)
            {
                return NotFound();
            }

            _context.Prescribes.Remove(prescribe);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PrescribeExists(int id)
        {
            return _context.Prescribes.Any(e => e.PrescriptionId == id);
        }
    }
}
