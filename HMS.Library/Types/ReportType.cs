using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.Library.Models;
using Microsoft.EntityFrameworkCore;

namespace HMS.Library.Types
{
	public class ReportType
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ReportTypeId { get; set; }

		public string Name { get; set; }

        //Navigation property
        public ICollection<Report>? Report { get; set; } = new List<Report>();
	}
}
