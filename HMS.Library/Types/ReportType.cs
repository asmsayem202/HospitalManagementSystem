using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.Library.Models;

namespace HMS.Library.Types
{
	public class ReportType
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ReportTypeID { get; set; }

		public string Name { get; set; }
		public int? ReportId { get; set; }

		//Navigation property

		public virtual ICollection<Report>? Report { get; set; } = new List<Report>();
	}
}
