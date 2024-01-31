using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Library.Models
{
	public class Doctor
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int DoctorID { get; set; }

		[Required, StringLength(150)]
		public string Name { get; set; }

		public string Specialization { get; set; }

		[Phone]
		public int ContactNo { get; set; }
		[EmailAddress]
		public string Email { get; set; }
		//(e.g., Sat-Thu 6-9)
		public string? Schedule { get; set; }



		//Navigation Property

		public virtual ICollection<Patient>? Patient { get; set; } = new List<Patient>();
		public virtual ICollection<Appointment>? Appointment { get; set; } = new List<Appointment>();


	}
}
