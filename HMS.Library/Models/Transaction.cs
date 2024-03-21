using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.Library.Types;
using Microsoft.EntityFrameworkCore;

namespace HMS.Library.Models
{
	public class Transaction
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int TransactionId { get; set; }

		[DataType(DataType.Date)]
		public DateTime TransactionDate { get; set; }

		public string Description { get; set; }

		[Required]
		public decimal Amount { get; set; }
		public decimal Discount { get; set; }
		public decimal NetAmount => Amount - Discount;
		public decimal PaidAmount { get; set; }
		public decimal BalanceDue => NetAmount - PaidAmount;

		//Transaction + Supplier join query
		public int? RefTypeID { get; set; }
		public TranRefType? RefType { get; set; }
	}

}
