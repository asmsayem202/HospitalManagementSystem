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
		public int BillingId { get; set; }
		public int PatientID { get; set; }

		[DataType(DataType.DateTime)]
		public DateTime DateTime { get; set; }

		public decimal? OT_Fee { get; set; } = 0;
		public decimal? MedicineFee { get; set; } = 0;
		public decimal? ConsultancyFee { get; set; } = 0;
		public decimal? BedCharge { get; set; } = 0;
		public decimal? ServiceCharge { get; set; } = 0;
		public decimal? OthersFee { get; set; } = 0;


		public decimal? Amount { get; set; } = 0;
		public decimal? Discount { get; set; } = 0;
		public decimal? NetAmount { get; set; } = 0;
		public decimal? PaidAmount { get; set; } = 0;
		public decimal? BalanceDue { get; set; } = 0;



		//Navigation Property
		public Patient? Patient { get; set; }


	}
}
