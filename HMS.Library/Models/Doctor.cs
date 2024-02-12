﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace HMS.Library.Models
{
	public class Doctor
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int DoctorID { get; set; }

		[Required, StringLength(150)]
		public string Name { get; set; }
		public string Specialization { get; set; }

		//[Phone]
		public int ContactNo { get; set; }
		[EmailAddress]
		public string Email { get; set; }
		//(e.g., Sat-Thu 6-9)
		public string? Schedule { get; set; }
		public string? Image { get; set; }
		public int? PatientId { get; set; }
		public int? AppointmentId { get; set; }

        //[NotMapped]
        //public IFormFile? ImageFile { get; set; }



        //Navigation Property
        public ICollection<Patient>? Patient { get; set; } = new List<Patient>();

        public ICollection<Appointment>? Appointment { get; set; } = new List<Appointment>();


	}
}
