using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Design;
using HMS.Library.Types;

namespace HMS.Library.Models
{
	public class Patient
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int PatientID { get; set; }

		[Required, StringLength(150)]
		public string Name { get; set; }

		[DataType(DataType.Date)]
		public DateOnly Dob { get; set; }

		public string Gender { get; set; }
		public int Age { get; set; }
		public int ContactNo { get; set; }

		[EmailAddress]
		public string? Email { get; set; }
		public string? Address { get; set; }
		public int BloodTypeId { get; set; }
		public string? InsuranceInformation { get; set; }

		//(e.g., Active, Discharged, Deceased)
		public string Status { get; set; }




		//Navigation property

		public virtual BloodType? BloodType { get; set; }

		public virtual ICollection<Admission>? Admission { get; set; } = new List<Admission>();
		public virtual ICollection<Appointment>? Appointment { get; set; } = new List<Appointment>();

		public virtual ICollection<Billing>? Billing { get; set; } = new List<Billing>();

	}
}
