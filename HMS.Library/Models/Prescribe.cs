using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Library.Models
{
	public class Prescribe
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int PrescriptionID { get; set; }
		public int PatientId { get; set; }


		[Required]
		[StringLength(50)]
		public string Medication { get; set; }
		public string? Dosgae { get; set; }
		public string? Instructions { get; set; }
		[Required]
		[DataType(DataType.DateTime)]
		public DateTime StartDate { get; set; }
		[Required]
		[DataType(DataType.DateTime)]

		public DateTime EndDate { get; set; }
		public string Status { get; set; }


		//Navigation Property

		public virtual ICollection<Patient>? Patient { get; set; } = new List<Patient>();
		public virtual ICollection<Appointment>? Appointment { get; set; } = new List<Appointment>();


	}
}
