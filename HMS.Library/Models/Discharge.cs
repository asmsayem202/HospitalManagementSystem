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
		public int DischargeID { get; set; }
		public int? PatientId { get; set; }


		[Required]
		[DataType(DataType.DateTime)]
		public DateTime DischargeDate { get; set; }

		public string? Reason { get; set; }

		public string? DischargeInstructions { get; set; }
		public int? AdmissionId { get; set; }



        //Navigation Property
        [DeleteBehavior(DeleteBehavior.Cascade)]
        public virtual Admission? Admission { get; set; }

        [DeleteBehavior(DeleteBehavior.Cascade)]
        public virtual Patient? Patient { get; set; }


	}
}
