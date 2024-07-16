﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HMS.Library.DAL;
using HMS.Library.Models;
using HMS.Api.Services;
using System.Numerics;

namespace HMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffsController : ControllerBase
    {
        private readonly HMSdb _context;
		private readonly ImageUploadService imageUpload;

		public StaffsController(HMSdb context, ImageUploadService imageUpload)
        {
            _context = context;
			this.imageUpload = imageUpload;
		}

        // GET: api/Staffs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Staff>>> GetStaffs()
        {
            return await _context.Staffs.ToListAsync();
        }

        // GET: api/Staffs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Staff>> GetStaff(int id)
        {
            var staff = await _context.Staffs.FindAsync(id);

            if (staff == null)
            {
                return NotFound();
            }

            return staff;
        }

        // PUT: api/Staffs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStaff(int id, Staff staff)
        {
            if (id != staff.StaffId)
            {
                return BadRequest();
			}

			if (staff.ImageUpload?.ImageData != null)
			{
				//staff.ImagePath = await imageUpload.Upload(doctor.ImageUpload);
				staff.ImagePath = staff.ImageUpload?.ImageData;
			}

			_context.Entry(staff).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaffExists(id))
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

		// POST: api/Staffs
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Staff>> PostStaff(Staff staff)
		{
			if (staff == null)
			{
				return NotFound();
			}
			if (staff.ImageUpload?.ImageData != null)
			{
				staff.ImagePath = staff.ImageUpload?.ImageData;
			}
			_context.Staffs.Add(staff);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetStaff", new { id = staff.StaffId }, staff);
		}


		// DELETE: api/Staffs/5
		[HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaff(int id)
        {
            var staff = await _context.Staffs.FindAsync(id);
            if (staff == null)
            {
                return NotFound();
            }

            _context.Staffs.Remove(staff);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StaffExists(int id)
        {
            return _context.Staffs.Any(e => e.StaffId == id);
        }
    }
}
