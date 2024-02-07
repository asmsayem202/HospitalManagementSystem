using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.Library.Types;
using Microsoft.EntityFrameworkCore;

namespace HMS.Library.Models
{
	public class Appointment
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int AppointmentID { get; set; }
		public int? PatientId { get; set; }
		public int? DoctorId { get; set; }

		//(e.g., Consultation, Procedure, Follow-up)
		public int? AppointmentTypeId { get; set; }

		//(e.g., Scheduled, Confirmed, Completed)
		public string? Status { get; set; }
		public int? PrescribeId { get; set; }


        //Navigation Property
        public virtual AppointmentType? AppointmentType { get; set; }

        public virtual ICollection<Patient>? Patient { get; set; } = new List<Patient>();

        public virtual Doctor? Doctor { get; set; }

        public virtual Prescribe? Prescribe { get; set; }
	}
}
