using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Library.Models
{
	public class Staff
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int StaffId { get; set; }
		[Required, StringLength(150)]
		public string StaffName { get; set; }
		public string Designation { get; set; }
		public string? Address { get; set; }
		public string ContactNo { get; set; }
		[EmailAddress]
		public string Email { get; set; }
		public ShiftType Shift { get; set; }

		public string? ImagePath { get; set; }

		[NotMapped]
		public ImageUpload? ImageUpload { get; set; }
	}

	public enum ShiftType
	{
		Morning_6am_To_2pm,
		Afternoon_2pm_To_10pm,
		Night_10pm_To_6am
	}
}
