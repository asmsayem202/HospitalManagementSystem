using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Library.Models
{
	public class Appointment
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int AppointmentID { get; set; }

		//(e.g., Consultation, Procedure, Follow-up)
		public string? AppointmentType { get; set; }

		//(e.g., Scheduled, Confirmed, Completed)
		public string? Status { get; set; }


		//Navigation Property

		public virtual Patient? Patient { get; set; }
		public virtual Doctor? Doctor { get; set; }
	}
}
