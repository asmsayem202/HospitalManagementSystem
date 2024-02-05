using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HMS.Library.DAL;
using HMS.Library.Types;
using Microsoft.AspNetCore.Authorization;

namespace HMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
	[Authorize]
	public class BloodTypesController : ControllerBase
    {
        private readonly HMSdb _context;

        public BloodTypesController(HMSdb context)
        {
            _context = context;
        }

        // GET: api/BloodTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BloodType>>> GetBloodTypes()
        {
            return await _context.BloodTypes.ToListAsync();
        }

        // GET: api/BloodTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BloodType>> GetBloodType(int id)
        {
            var bloodType = await _context.BloodTypes.FindAsync(id);

            if (bloodType == null)
            {
                return NotFound();
            }

            return bloodType;
        }

        // PUT: api/BloodTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBloodType(int id, BloodType bloodType)
        {
            if (id != bloodType.BloodTypeID)
            {
                return BadRequest();
            }

            _context.Entry(bloodType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BloodTypeExists(id))
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

        // POST: api/BloodTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BloodType>> PostBloodType(BloodType bloodType)
        {
            _context.BloodTypes.Add(bloodType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBloodType", new { id = bloodType.BloodTypeID }, bloodType);
        }

        // DELETE: api/BloodTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBloodType(int id)
        {
            var bloodType = await _context.BloodTypes.FindAsync(id);
            if (bloodType == null)
            {
                return NotFound();
            }

            _context.BloodTypes.Remove(bloodType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BloodTypeExists(int id)
        {
            return _context.BloodTypes.Any(e => e.BloodTypeID == id);
        }
    }
}
