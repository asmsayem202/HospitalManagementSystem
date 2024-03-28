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
	public class Report
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ReportId { get; set; }
		public int PatientID { get; set; }


		public string Title { get; set; }

		[DataType(DataType.Date)]
		public DateTime? CreationDate { get; set; }
		public int ReportTypeID { get; set; }

		public string ReportAuthor { get; set; }
		public string ReportContent { get; set; }


        //Navigation Property
        public ReportType? ReportType { get; set; }

        public Patient? Patient { get; set; }


	}
}
