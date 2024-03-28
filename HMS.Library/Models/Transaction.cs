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

		public string? Description { get; set; }

		[Required]
		public decimal Amount { get; set; }
		public decimal PaidAmount { get; set; }
		public decimal BalanceDue => Amount - PaidAmount;

		//Transaction + Supplier join query
		public int? RefTypeID { get; set; }
		public string? RefTypeName { get; set; }
	}

}
