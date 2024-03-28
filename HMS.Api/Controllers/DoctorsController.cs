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
    public class DoctorsController : ControllerBase
    {
        private readonly HMSdb _context;
		private readonly ImageUploadService imageUpload;

		public DoctorsController(HMSdb context, ImageUploadService imageUpload)
        {
            _context = context;
			this.imageUpload = imageUpload;
		}

        // GET: api/Doctors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctors()
        {
            try
            {
				return await _context.Doctors.ToListAsync();
			}
            catch (Exception ex)
            {
                return NotFound(ex);
            }
           
        }

        // GET: api/Doctors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Doctor>> GetDoctor(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);

            if (doctor == null)
            {
                return NotFound();
            }

            return doctor;
        }

        // PUT: api/Doctors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoctor(int id, Doctor doctor)
        {
            if (id != doctor.DoctorId)
            {
                return BadRequest();
            }


			if (doctor.ImageUpload?.ImageData != null)
			{
				//Doctor.ImagePath = await imageUpload.Upload(doctor.ImageUpload);
				doctor.ImagePath = doctor.ImageUpload?.ImageData;

			}

			_context.Entry(doctor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoctorExists(id))
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

		// POST: Doctors
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Doctor>> PostDoctor(Doctor doctor)
		{

			if (doctor.ImageUpload?.ImageData != null)
			{
				//Doctor.ImagePath = await imageUpload.Upload(doctor.ImageUpload);
				doctor.ImagePath = doctor.ImageUpload?.ImageData;

			}




			_context.Doctors.Add(doctor);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetDoctor", new { id = doctor.DoctorId }, doctor);
		}

		// DELETE: api/Doctors/5
		[HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }

            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DoctorExists(int id)
        {
            return _context.Doctors.Any(e => e.DoctorId == id);
        }
    }
}
