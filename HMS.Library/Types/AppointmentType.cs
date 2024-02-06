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
	public class AppointmentType
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int AppointmentTypeID { get; set; }
		public string Name { get; set; }

        public virtual ICollection<Appointment>? Appointment { get; set; } = new List<Appointment>();

    }
}
