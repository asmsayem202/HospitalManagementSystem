using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Library.Models
{
	public class Followup
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int FollowupID { get; set; }
		public int PatientId { get; set; }


		[Required]
		[StringLength(50)]
		public string Reason { get; set; }

		public string? Notes { get; set; }
		public string Status { get; set; }

		//Navigation Property

		public virtual ICollection<Patient>? Patient { get; set; } = new List<Patient>();

	}
}
