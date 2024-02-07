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
        [DeleteBehavior(DeleteBehavior.Cascade)]
        public virtual ICollection<Patient>? Patient { get; set; } = new List<Patient>();

        [DeleteBehavior(DeleteBehavior.Cascade)]
        public virtual Report? Report { get; set; }

        [DeleteBehavior(DeleteBehavior.Cascade)]
        public virtual Discharge? Discharge { get; set; }


	}
}
