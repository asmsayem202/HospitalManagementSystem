using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Library.Models
{
	public class Billing
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int BillingID { get; set; }
		public int PatientId { get; set; }


		[DataType(DataType.DateTime)]
		public DateTime DateTime { get; set; }

		public decimal Amount { get; set; }

		//Navigation Property

		public virtual Patient? Patient { get; set; }
		public virtual Report? Report { get; set; }
		public virtual Discharge? Discharge { get; set; }


	}
}
