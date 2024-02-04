using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.Library.Types;

namespace HMS.Library.Models
{
	public class Report
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ReportID { get; set; }
		public int PatientId { get; set; }


		public string Title { get; set; }

		[DataType(DataType.Date)]
		public DateTime? CreationDate { get; set; }
		public int ReportTypeId { get; set; }

		public string ReportAuthor { get; set; }
		public string ReportContent { get; set; }


		//Navigation Property
		public virtual ReportType? ReportType { get; set; }
		public virtual ICollection<Patient>? Patient { get; set; } = new List<Patient>();


	}
}
