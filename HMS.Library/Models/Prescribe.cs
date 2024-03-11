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
	public class Prescribe
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int PrescriptionId { get; set; }
		public int? PatientID { get; set; }


		[Required]
		[StringLength(250)]
		public string Medication { get; set; }
		public string? Dosgae { get; set; }
		public string? Instructions { get; set; }
		[Required]
		[DataType(DataType.DateTime)]
		public DateTime StartDate { get; set; }
		[Required]
		[DataType(DataType.DateTime)]

		public DateTime EndDate { get; set; }
		public string? Status { get; set; }


        //Navigation Property
        public Patient? Patient { get; set; }


	}
}
