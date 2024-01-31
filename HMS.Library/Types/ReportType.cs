using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Library.Types
{
	public class ReportType
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ReportTypeID { get; set; }

		public string Name { get; set; }
	}
}
