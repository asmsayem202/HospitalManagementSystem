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
	public class Appointment
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int AppointmentId { get; set; }
		public int? PatientID { get; set; }
		public int? DoctorID { get; set; }
		public int? DepartmentID { get; set; }

		[DataType(DataType.DateTime)]
		public DateTime AppointmentDate { get; set; }

		//(e.g., Consultation, Procedure, Follow-up)
		public int? AppointmentTypeID { get; set; }
		public int? PrescribeID { get; set; }
		

        //Navigation Property
        public AppointmentType? AppointmentType { get; set; }

        public Patient? Patient { get; set; }
 
        public Doctor? Doctor { get; set; }
        public Department? Department { get; set; }

        public Prescribe? Prescribe { get; set; }
	}
}
