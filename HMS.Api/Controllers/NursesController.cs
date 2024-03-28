using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HMS.Library.DAL;
using HMS.Library.Models;
using HMS.Api.Services;

namespace HMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NursesController : ControllerBase
    {
        private readonly HMSdb _context;
		private readonly ImageUploadService imageUpload;

		public NursesController(HMSdb context, ImageUploadService imageUpload)
        {
            _context = context;
			this.imageUpload = imageUpload;
		}

        // GET: api/Nurses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nurse>>> GetNurses()
        {
            return await _context.Nurses.Include(w=>w.Ward).ToListAsync();
        }

        // GET: api/Nurses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Nurse>> GetNurse(int id)
        {
            var nurse = await _context.Nurses.Include(d => d.Ward).FirstOrDefaultAsync(m => m.NurseId == id);

			if (nurse == null)
            {
                return NotFound();
            }

            return nurse;
        }

		// PUT: api/Nurses/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutNurse(int id, Nurse nurse)
		{
			if (id != nurse.NurseId)
			{
				return BadRequest();
			}
			if (nurse.ImageUpload?.ImageData != null)
			{
				//Nurse.ImagePath = await imageUpload.Upload(nurse.ImageUpload);
				nurse.ImagePath = nurse.ImageUpload?.ImageData;

			}
			_context.Entry(nurse).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!NurseExists(id))
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

		// POST: api/Nurses
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Nurse>> PostNurse(Nurse nurse)
		{
			if (nurse.ImageUpload?.ImageData != null)
			{
				//Nurse.ImagePath = await imageUpload.Upload(nurse.ImageUpload);
				nurse.ImagePath = nurse.ImageUpload?.ImageData;

			}

			_context.Nurses.Add(nurse);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetNurse", new { id = nurse.NurseId }, nurse);
		}

		// DELETE: api/Nurses/5
		[HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNurse(int id)
        {
            var nurse = await _context.Nurses.FindAsync(id);
            if (nurse == null)
            {
                return NotFound();
            }

            _context.Nurses.Remove(nurse);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NurseExists(int id)
        {
            return _context.Nurses.Any(e => e.NurseId == id);
        }
    }
}
