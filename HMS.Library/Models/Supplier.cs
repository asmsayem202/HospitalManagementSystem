using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Library.Models
{
	public class Supplier
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int SupplierId { get; set; }

		[Required]
		[StringLength(150)]
		public string Name { get; set; }

		[Required]
		[EmailAddress]
		[StringLength(50)]
		public string Email { get; set; }

		[Required]
		public string Phone { get; set; }

		[DataType(DataType.MultilineText)]
		[StringLength(250)]
		public string SupplierAddress { get; set; }
		public int InventoryItemsID { get; set; }
		public int TransactionsID { get; set; }


		//Navigation Property
		public ICollection<InventoryItem>? InventoryItems { get; set; } = new List<InventoryItem>();
		public ICollection<Transaction>? Transactions { get; set; } = new List<Transaction>();


	}
}
