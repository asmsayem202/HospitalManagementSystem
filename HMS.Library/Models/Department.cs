using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Library.Models
{
	public class Department
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int DepartmentID { get; set; }
		[Required]
		public string DepartmentName { get; set; }

		//Navigation Property

		public virtual Admission? Admission { get; set; }
		public virtual Patient? Patient { get; set; }
		public virtual Doctor? Doctor { get; set; }
		public virtual Ward? Ward { get; set; }
	}
}
