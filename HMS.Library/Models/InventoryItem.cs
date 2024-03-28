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
	public class InventoryItem
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int InventoryItemId { get; set; }
		[Required]
		[StringLength(150)]
		public string Name { get; set; }
		[Required]

		public decimal Price { get; set; }
		[Required]
		public int Quantity { get; set; }
		public string Category { get; set; }
		public int? SupplierID { get; set; }

		//Navigation Property
		public Supplier? Supplier { get; set; }
	}
}
