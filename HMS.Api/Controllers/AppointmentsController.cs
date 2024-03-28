using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HMS.Library.DAL;
using HMS.Library.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace HMS.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class AppointmentsController : ControllerBase
	{
		private readonly HMSdb _context;

		public AppointmentsController(HMSdb context)
		{
			_context = context;
		}

		// GET: api/Appointments
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointments()
		{
			return await _context.Appointments.Include(a => a.Doctor).Include(a => a.Patient).Include(a => a.Department).Include(a => a.AppointmentType).Include(a => a.AppointmentPrescribe).ToListAsync();
		}

		// GET: api/Appointments/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Appointment>> GetAppointment(int id)
		{
			// var appointment = await _context.Appointments.FindAsync(id);
			var appointment = await _context.Appointments.Include(a => a.Doctor).Include(a => a.Patient).Include(a => a.Department).Include(a => a.AppointmentType).Include(a => a.AppointmentPrescribe).FirstOrDefaultAsync(a => a.AppointmentId == id);
		
			if (appointment == null)
			{
				return NotFound();
			}			

			return appointment;
		}

		// PUT: api/Appointments/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutAppointment(int id, Appointment appointment)
		{
			if (id != appointment.AppointmentId)
			{
				return BadRequest();
			}

			try
			{
				_context.Entry(appointment).State = EntityState.Modified;
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!AppointmentExists(id))
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

		// POST: api/Appointments
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		
		[HttpPost]
		public async Task<ActionResult<Appointment>> PostAppointment(Appointment appointment)
		{
			try
			{
				_context.Appointments.Add(appointment);
				await _context.SaveChangesAsync();

				return CreatedAtAction("GetAppointment", new { id = appointment.AppointmentId }, appointment);
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				return BadRequest(ex.Message);
			}
		}


		// DELETE: api/Appointments/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAppointment(int id)
		{
			var appointment = await _context.Appointments.FindAsync(id);
			if (appointment == null)
			{
				return NotFound();
			}

			_context.Appointments.Remove(appointment);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool AppointmentExists(int id)
		{
			return _context.Appointments.Any(e => e.AppointmentId == id);
		}



		
		[HttpGet("GetPrescription/{id}")]
        [Authorize(Roles = "Admin , Manager, Doctor")]
        public async Task<ActionResult<Appointment>> GetPrescription(int id)
		{
			// var appointment = await _context.Appointments.FindAsync(id);
			var appointment = await _context.Appointments.Include(a => a.Doctor).Include(a => a.Patient).Include(a => a.Department).Include(a => a.AppointmentType).Include(a => a.AppointmentPrescribe).ThenInclude(a=> a.AppointmentPrescribeDetails).FirstOrDefaultAsync(a => a.AppointmentId == id);
			if (appointment == null)
			{
				return NotFound();
			}

			if (appointment.AppointmentPrescribe == null)
			{
				appointment.AppointmentPrescribe = new AppointmentPrescribe()
				{
					AppointmentID = id
				};

			}

			return appointment;
		}

		[HttpPost("SetPrescription")]
        [Authorize(Roles = "Doctor, Admin")]
        [EnableCors()]
        public async Task<ActionResult<Appointment>> SetPrescription(Appointment appointment)
		{
			try
			{
				if (appointment.AppointmentPrescribe != null)
				{

					var appointmentUpdate = _context.Appointments.Include(a => a.Doctor).Include(a => a.Patient).Include(a => a.Department).Include(a => a.AppointmentType).Include(a => a.AppointmentPrescribe).SingleOrDefault(a => a.AppointmentId == appointment.AppointmentId);

					if (appointmentUpdate?.AppointmentPrescribe == null)
					{
						_context.AppointmentPrescribes.Add(appointment.AppointmentPrescribe);
					}
					else
					{
						appointmentUpdate.AppointmentPrescribe = appointment.AppointmentPrescribe;
						_context.Entry(appointmentUpdate).State = EntityState.Modified;
					}
					await _context.SaveChangesAsync();
				}
				return Ok();
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				return BadRequest(ex.Message);
			}
		}
	}
}
