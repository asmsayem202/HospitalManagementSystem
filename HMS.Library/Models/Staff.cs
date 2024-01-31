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
		public int StaffID { get; set; }
		[Required, StringLength(150)]
		public string StaffName { get; set; }
		public string? Address { get; set; }
		public string ContactInfo { get; set; }
	}
}
