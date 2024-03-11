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
	public class Admission
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int AdmissionId { get; set; }

		[DataType(DataType.DateTime)]
		public DateTime AdmissionDate { get; set; }
		public int? AppointmentID { get; set; }
		public int? EmergencyID { get; set; }
		public int? FollowupID { get; set; }
		public int? WardID { get; set; }


        //Navigation Property

        public Appointment? Appointment { get; set; }

        public Emergency? Emergency { get; set; }

        public Followup? Followup { get; set; }

        public Ward? Ward { get; set; }
	}
}
