using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Library.Models
{
	public class Admission
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int AdmissionID { get; set; }
		public int PatientId { get; set; }
		public int DoctorId { get; set; }

		[DataType(DataType.DateTime)]
		public DateTime AdmissionDate { get; set; }


		//Navigation Property

		public virtual Patient? Patient { get; set; }
		public virtual Doctor? Doctor { get; set; }
		public virtual Appointment? Appointment { get; set; }
		public virtual Emergency? Emergency { get; set; }
		public virtual Followup? Followup { get; set; }
		public virtual Ward? Ward { get; set; }
	}
}
