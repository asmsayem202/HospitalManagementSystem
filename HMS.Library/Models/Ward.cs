﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HMS.Library.Models
{
	public class Ward
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int WardId { get; set; }
		[Required]
		public string? WardName { get; set; }
		public int? DepartmentID { get; set; }
		public int? PatientID { get; set; }



		//Navigation Property
		public Department? Department { get; set; }
		public Patient? Patient { get; set; }

		public ICollection<Nurse>? Nurses { get; set; } = new List<Nurse>();

        public ICollection<Room>? Rooms { get; set; } = new List<Room>();


	}
}
