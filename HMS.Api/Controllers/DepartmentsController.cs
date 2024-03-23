using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HMS.Library.DAL;
using HMS.Library.Models;
using Microsoft.AspNetCore.Authorization;

namespace HMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly HMSdb _context;

        public DepartmentsController(HMSdb context)
        {
            _context = context;
        }

        // GET: api/Departments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
        {
            return await _context.Departments.Include(i => i.Doctors).ToListAsync();
		}

        // GET: api/Departments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartment(int id)
        {
            var department = await _context.Departments.Include(d=>d.Doctors).FirstOrDefaultAsync(m => m.DepartmentId == id);

			if (department == null)
            {
                return NotFound();
            }

            return department;
        }

        // PUT: api/Departments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartment(int id, Department department)
        {
            if (id != department.DepartmentId)
            {
                return BadRequest();
            }

            //_context.Entry(department).State = EntityState.Modified;

            try
            {
				_context.Update(department);

				var itemsIdList = department.Doctors.Select(d => d.DoctorId).ToList();

				var delItems = await _context.Doctors.Where(i => i.DepartmentID == id).Where(i => !itemsIdList.Contains(i.DoctorId)).ToListAsync();

				_context.Doctors.RemoveRange(delItems);


				await _context.SaveChangesAsync();
			}
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(id))
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

        // POST: api/Departments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Department>> PostDepartment(Department department)
        {
            try
            {
				_context.Departments.Add(department);
				await _context.SaveChangesAsync();

				return CreatedAtAction("GetDepartment", new { id = department.DepartmentId }, department);
			}
            catch (Exception)
            {

                throw;
            }
           
        }

        // DELETE: api/Departments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DepartmentExists(int id)
        {
            return _context.Departments.Any(e => e.DepartmentId == id);
        }
    }
}
