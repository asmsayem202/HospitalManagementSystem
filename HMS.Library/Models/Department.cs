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
		public int DepartmentId { get; set; }
		[Required]
		public string Name { get; set; }

        //Navigation Property
        

		public ICollection<Doctor>? Doctors { get; set; } = new List<Doctor>();
	}
}
