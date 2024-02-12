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
		public int AdmissionID { get; set; }
		public int? PatientId { get; set; }
		public int? DoctorId { get; set; }

		[DataType(DataType.DateTime)]
		public DateTime AdmissionDate { get; set; }
		public int? AppointmentId { get; set; }
		public int? EmergencyId { get; set; }
		public int? FollowupId { get; set; }
		public int? WardId { get; set; }


        //Navigation Property
        
        public Patient? Patient { get; set; }

        public Doctor? Doctor { get; set; }

        public Appointment? Appointment { get; set; }

        public Emergency? Emergency { get; set; }

        public Followup? Followup { get; set; }

        public Ward? Ward { get; set; }
	}
}
