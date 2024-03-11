using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HMS.Library.Models
{
	public class Followup
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int FollowupId { get; set; }
		public int? PatientID { get; set; }

		public string? Reason { get; set; }

		public string? Notes { get; set; }

		[Required]
		public string Status { get; set; }

        //Navigation Property
        public Patient? Patient { get; set; }

	}
}
