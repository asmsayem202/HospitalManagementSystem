using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.Library.Types;

namespace HMS.Library.Models
{
	public class Appointment
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int AppointmentID { get; set; }
		public int PatientId { get; set; }
		public int DoctorId { get; set; }

		//(e.g., Consultation, Procedure, Follow-up)
		public AppointmentType? Type { get; set; }

		//(e.g., Scheduled, Confirmed, Completed)
		public string? Status { get; set; }


		//Navigation Property

		public virtual Patient? Patient { get; set; }
		public virtual Doctor? Doctor { get; set; }
		public virtual Admission? Admission { get; set; }
		public virtual Prescribe? Prescribe { get; set; }
	}
}
