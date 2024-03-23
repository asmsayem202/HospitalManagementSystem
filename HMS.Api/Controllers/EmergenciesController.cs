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
    public class EmergenciesController : ControllerBase
    {
        private readonly HMSdb _context;

        public EmergenciesController(HMSdb context)
        {
            _context = context;
        }

        // GET: api/Emergencies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Emergency>>> GetEmergencies()
        {
            return await _context.Emergencies.ToListAsync();
        }

        // GET: api/Emergencies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Emergency>> GetEmergency(int id)
        {
            var emergency = await _context.Emergencies.FindAsync(id);

            if (emergency == null)
            {
                return NotFound();
            }

            return emergency;
        }

        // PUT: api/Emergencies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmergency(int id, Emergency emergency)
        {
            if (id != emergency.EmergencyId)
            {
                return BadRequest();
            }

            _context.Entry(emergency).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmergencyExists(id))
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

        // POST: api/Emergencies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Emergency>> PostEmergency(Emergency emergency)
        {
            _context.Emergencies.Add(emergency);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmergency", new { id = emergency.EmergencyId }, emergency);
        }

        // DELETE: api/Emergencies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmergency(int id)
        {
            var emergency = await _context.Emergencies.FindAsync(id);
            if (emergency == null)
            {
                return NotFound();
            }

            _context.Emergencies.Remove(emergency);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmergencyExists(int id)
        {
            return _context.Emergencies.Any(e => e.EmergencyId == id);
        }
    }
}
