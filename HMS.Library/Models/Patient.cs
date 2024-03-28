using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Design;
using HMS.Library.Types;
using Microsoft.EntityFrameworkCore;

namespace HMS.Library.Models
{
	public class Patient
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int PatientId { get; set; }

		[Required, StringLength(150)]
		public string Name { get; set; }

		[DataType(DataType.Date)]
		public DateOnly? Dob { get; set; }

		public Genders Gender { get; set; } = Genders.Other;
		public int? Age { get; set; }
		public string ContactNo { get; set; }

		[EmailAddress]
		public string? Email { get; set; }
		public string? Address { get; set; }
		public int? BloodTypeID { get; set; }
		public string? InsuranceInformation { get; set; }

		//(e.g., Active, Discharged, Deceased)
		public string? Status { get; set; }




        //Navigation property
        public BloodType? BloodType { get; set; }

        public ICollection<Doctor>? Doctor { get; set; } = new List<Doctor>();

        public ICollection<Emergency>? Emergency { get; set; } = new List<Emergency>();

        public ICollection<Followup>? Followup { get; set; } = new List<Followup>();

        public ICollection<Prescribe>? Prescribe { get; set; } = new List<Prescribe>();

        public ICollection<Report>? Report { get; set; } = new List<Report>();

        public ICollection<Ward>? Ward { get; set; } = new List<Ward>();

        public ICollection<Admission>? Admission { get; set; } = new List<Admission>();

        public ICollection<Appointment>? Appointment { get; set; } = new List<Appointment>();

        public ICollection<Billing>? Billing { get; set; } = new List<Billing>();

	}

	public enum Genders
	{
		Other,
		Male,
		Female
		
	}
}
