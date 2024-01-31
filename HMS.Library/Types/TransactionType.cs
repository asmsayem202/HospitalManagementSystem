using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Library.Types
{
	public class TransactionType
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int TransactionTypeID { get; set; }

		public string Name { get; set; }
	}
}
