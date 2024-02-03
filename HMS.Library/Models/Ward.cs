using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Library.Models
{
	public class Ward
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int WardID { get; set; }
		[Required]
		public string? WardName { get; set; }



		//Navigation Property
		public virtual ICollection<Admission>? Admission { get; set; } = new List<Admission>();

		public virtual ICollection<Patient>? Patient { get; set; } = new List<Patient>();
		public virtual Nurse? Nurse { get; set; }
		public virtual Room? Room { get; set; }
	}
}
