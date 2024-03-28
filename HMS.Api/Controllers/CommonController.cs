using System;
using HMS.Library.DAL;
using HMS.Library.Models;
using HMS.Library.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CommonController : ControllerBase
	{
		private readonly HMSdb _context;
		public CommonController(HMSdb context) 
		{
			_context = context;
		}

		[HttpGet("GetShiftType")]
		public ActionResult<string[]> GetShiftType()
		{
			string[] shiftTypes = Enum.GetNames(typeof(ShiftType));
			return Ok(shiftTypes);
		}

		[HttpGet("GetGender")]
		public ActionResult<string[]> GetGender()
		{
			string[] gender = Enum.GetNames(typeof(Genders));
			return Ok(gender);
		}

		[HttpGet("GetBloodType")]
		public ActionResult<BloodType[]> GetBloodType()
		{
			BloodType[] data = _context.BloodTypes.ToArray();
			return Ok(data);
		}

		[HttpGet("GetAppointmentType")]
		public ActionResult<AppointmentType[]> GetAppointmentType()
		{
			AppointmentType[] data = _context.AppointmentTypes.ToArray();
			return Ok(data);
		}

		[HttpGet("GetPatient")]
		public ActionResult<Patient[]> GetPatient()
		{
			Patient[] data = _context.Patients.ToArray();
			return Ok(data);
		}

		[HttpGet("GetDepartment")]
		public ActionResult<Department[]> GetDepartment()
		{
			Department[] data = _context.Departments.ToArray();
			return Ok(data);
		}

		[HttpGet("GetDoctor")]
		public ActionResult<Doctor[]> GetDoctor()
		{
			Doctor[] data = _context.Doctors.ToArray();
			return Ok(data);
		}
		
		[HttpGet("GetAppointment")]
		public ActionResult<Appointment[]> GetAppointment()
		{
			Appointment[] data = _context.Appointments.ToArray();
			return Ok(data);
		}
		
		[HttpGet("GetEmergency")]
		public ActionResult<Emergency[]> GetEmergency()
		{
			Emergency[] data = _context.Emergencies.ToArray();
			return Ok(data);
		}

		[HttpGet("GetAdmission")]
		public ActionResult<Admission[]> GetAdmission()
		{
			Admission[] data = _context.Admissions.ToArray();
			return Ok(data);
		}

		[HttpGet("GetWard")]
		public ActionResult<Ward[]> GetWard()
		{
			Ward[] data = _context.Wards.ToArray();
			return Ok(data);
		}
		
		[HttpGet("GetNurse")]
		public ActionResult<Nurse[]> GetNurse()
		{
			Nurse[] data = _context.Nurses.ToArray();
			return Ok(data);
		}
		
		[HttpGet("GetRoom")]
		public ActionResult<Room[]> GetRoom()
		{
			Room[] data = _context.Rooms.ToArray();
			return Ok(data);
		}

	}
}
