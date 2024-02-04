using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Library.Models
{
	public class Emergency
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int EmergencyID { get; set; }
		public int PatientId { get; set; }


		[StringLength(50)]
		public string? Location { get; set; }
		[DataType(DataType.DateTime)]
		public DateTime EmergencyDateTime { get; set; }
		[Required]
		public string Description { get; set; }
		public string Severity { get; set; }
		public string Status { get; set; }

		//Navigation property

		public virtual ICollection<Patient>? Patient { get; set; } = new List<Patient>();

	}
}
