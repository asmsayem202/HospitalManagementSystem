using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HMS.Library.Models
{
	public class Admission
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int AdmissionId { get; set; }

		[DataType(DataType.DateTime)]
		public DateTime AdmissionDate { get; set; }
		public int? AppointmentID { get; set; }
		public int? EmergencyID { get; set; }
		public int WardID { get; set; }
		public int NurseID { get; set; }
		public int RoomID { get; set; }
		public AdmissionType AdmissionType { get; set; } = AdmissionType.Appointment;


		//Navigation Property

		public Appointment? Appointment { get; set; }

		public Emergency? Emergency { get; set; }

		public Ward? Ward { get; set; }
		public Nurse? Nurse { get; set; }
		public Room? Room { get; set; }
	}

	public enum AdmissionType
	{
		Appointment,
		Emergency,
	}
}
