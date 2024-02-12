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
	public class Department
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int DepartmentID { get; set; }
		[Required]
		public string DepartmentName { get; set; }
		public int? DoctorId { get; set; }
		public int? WardId { get; set; }

        //Navigation Property
        

		public ICollection<Doctor>? doctors { get; set; } = new List<Doctor>();
		public Ward? Ward { get; set; }
	}
}
