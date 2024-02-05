using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.Library.Models;

namespace HMS.Library.Types
{
	public class BloodType
	{
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BloodTypeID { get; set; }
        public string Name { get; set; }
		public int? PatientId { get; set; }

		//Navigation
		public virtual ICollection<Patient>? Patient { get; set; } = new List<Patient>();
	}
}
