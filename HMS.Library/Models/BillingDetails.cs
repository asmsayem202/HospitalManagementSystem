using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Library.Models
{
	public class BillingDetails
	{
        public int BillingDetailsId { get; set; }
        public string Name { get; set; }
		public decimal Amount { get; set; }
		public decimal Discount { get; set; }
		public decimal NetAmount => Amount - Discount;
		public decimal PaidAmount { get; set; }
		public decimal BalanceDue => NetAmount - PaidAmount;
		public int? BillingID { get; set; }
		//Navigation Property
		public Billing? Billing { get; set; }
	}
}
