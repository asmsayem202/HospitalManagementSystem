using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HMS.Library.DAL;
using HMS.Library.Models;
using Microsoft.Extensions.Hosting;
using HMS.Api.ModelsData;
using Microsoft.AspNetCore.Authorization;

namespace HMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DoctorsController : ControllerBase
    {
        private readonly HMSdb _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public DoctorsController(HMSdb context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: api/Doctors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctors()
        {
            return await _context.Doctors.ToListAsync();
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


        private async Task<string> UploadImage(DoctorData doctorData)
        {
            string fileName = Path.GetFileNameWithoutExtension(doctorData.ImageUpload.FileName);
            string fileExt = Path.GetExtension(doctorData.ImageUpload.FileName);

            string imagepath = $"\\Images\\{fileName}_{Guid.NewGuid()}{fileExt}";

            //string imagepath = "\\Images\\" + doctorData.ImageUpload.FileName;


            string filepath = _hostEnvironment.WebRootPath + imagepath;

            using (FileStream filestream = System.IO.File.Create(filepath))
            {
                await doctorData.ImageUpload.CopyToAsync(filestream);
                await filestream.FlushAsync();
            }

            doctorData.Image = imagepath;
            return imagepath;
        }


        // PUT: api/Doctors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoctor(int id, DoctorData doctorData)
        {
            if (id != doctorData.DoctorId)
            {
                return BadRequest();
            }


            if (doctorData.ImageUpload != null)
            {

                try
                {
                    doctorData.Image = await UploadImage(doctorData);

                }
                catch (Exception ex)
                {

                    return BadRequest(ex.Message);
                }

            }


            _context.Entry<Doctor>(doctorData).State = EntityState.Modified;

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

        // POST: api/Doctors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Doctor>> PostDoctor(DoctorData doctorData)
        {

            if (doctorData.ImageUpload != null)
            {

                try
                {
                    doctorData.Image = await UploadImage(doctorData);

                }
                catch (Exception ex)
                {

                    return BadRequest(ex.Message);
                }

            }

            _context.Doctors.Add(doctorData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDoctor", new { id = doctorData.DoctorId }, doctorData);
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
