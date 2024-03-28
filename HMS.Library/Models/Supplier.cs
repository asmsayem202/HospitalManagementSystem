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
		public string ContactNo { get; set; }

		[DataType(DataType.MultilineText)]
		[StringLength(250)]
		public string? Address { get; set; }


		//Navigation Property
		public ICollection<InventoryItem>? InventoryItems { get; set; } = new List<InventoryItem>();


	}
}
