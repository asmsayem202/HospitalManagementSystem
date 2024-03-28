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
	public class Discharge
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int DischargeId { get; set; }
		public int AdmissionID { get; set; }


		[Required]
		[DataType(DataType.DateTime)]
		public DateTime DischargeDate { get; set; }

		public string? Reason { get; set; }

		public string? DischargeInstructions { get; set; }



        //Navigation Property
        public Admission? Admission { get; set; }



	}
}
