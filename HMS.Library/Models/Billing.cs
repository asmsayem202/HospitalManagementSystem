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
	public class Billing
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int BillingID { get; set; }
		public int? PatientId { get; set; }


		[DataType(DataType.DateTime)]
		public DateTime DateTime { get; set; }

		public decimal Amount { get; set; }
		public int? ReportId { get; set; }
		public int? DischargeId { get; set; }



        //Navigation Property
        public Patient? Patient { get; set; }

        public Report? Report { get; set; }

        public Discharge? Discharge { get; set; }


	}
}
