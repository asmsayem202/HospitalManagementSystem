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
		public int? BloodTypeId { get; set; }
		public string? InsuranceInformation { get; set; }

		//(e.g., Active, Discharged, Deceased)
		public string Status { get; set; }
		public int? AdmissionId { get; set; }
		public int? AppointmentId { get; set; }
		public int? BillingId { get; set; }
		public int? DoctorId { get; set; }
		public int? EmergencyId { get; set; }
		public int? FollowupId { get; set; }
		public int? PrescribeId { get; set; }
		public int? ReportId { get; set; }
		public int? WardId { get; set; }




		//Navigation property

		public virtual ICollection<BloodType>? BloodType { get; set; } = new List<BloodType>();
		public virtual ICollection<Doctor>? Doctor { get; set; } = new List<Doctor>();
		public virtual ICollection<Emergency>? Emergency { get; set; } = new List<Emergency>();
		public virtual ICollection<Followup>? Followup { get; set; } = new List<Followup>();
		public virtual ICollection<Prescribe>? Prescribe { get; set; } = new List<Prescribe>();
		public virtual ICollection<Report>? Report { get; set; } = new List<Report>();
		public virtual ICollection<Ward>? Ward { get; set; } = new List<Ward>();
		public virtual ICollection<Admission>? Admission { get; set; } = new List<Admission>();
		public virtual ICollection<Appointment>? Appointment { get; set; } = new List<Appointment>();
		public virtual ICollection<Billing>? Billing { get; set; } = new List<Billing>();

	}
}
