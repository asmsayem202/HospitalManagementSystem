using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Library.Models
{
	public class Nurse
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int NurseId { get; set; }
		[Required, StringLength(150)]
		public string Name { get; set; }
		[Phone]
		public string ContactNo { get; set; }
		public ShiftType Shift { get; set; }

		public int? WardID { get; set; }
		//Navigation Property
		public Ward? Ward { get; set; }

	}
}
