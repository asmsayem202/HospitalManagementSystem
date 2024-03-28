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
    public class AdmissionsController : ControllerBase
    {
        private readonly HMSdb _context;

        public AdmissionsController(HMSdb context)
        {
            _context = context;
        }

        // GET: api/Admissions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Admission>>> GetAdmissions()
        {
            return await _context.Admissions.Include(a => a.Appointment).Include(a => a.Emergency).Include(a => a.Room).ThenInclude(r=> r.Ward).ToListAsync();
		}

        // GET: api/Admissions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Admission>> GetAdmission(int id)
        {
            var admission = await _context.Admissions.Include(a => a.Appointment).Include(a => a.Emergency).Include(a => a.Room).ThenInclude(r => r.Ward).FirstOrDefaultAsync(a => a.AdmissionId == id);

			if (admission == null)
            {
                return NotFound();
            }

            return admission;
        }

        // PUT: api/Admissions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdmission(int id, Admission admission)
        {
            if (id != admission.AdmissionId)
            {
                return BadRequest();
            }

            _context.Entry(admission).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdmissionExists(id))
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

        // POST: api/Admissions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Admission>> PostAdmission(Admission admission)
        {
            _context.Admissions.Add(admission);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdmission", new { id = admission.AdmissionId }, admission);
        }

        // DELETE: api/Admissions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdmission(int id)
        {
            var admission = await _context.Admissions.FindAsync(id);
            if (admission == null)
            {
                return NotFound();
            }

            _context.Admissions.Remove(admission);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdmissionExists(int id)
        {
            return _context.Admissions.Any(e => e.AdmissionId == id);
        }
    }
}
