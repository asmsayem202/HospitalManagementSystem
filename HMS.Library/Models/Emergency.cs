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
	public class Emergency
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int EmergencyId { get; set; }
		public int PatientID { get; set; }
		public int DoctorID { get; set; }
		public int DepartmentID { get; set; }

		[StringLength(50)]
		public string? Location { get; set; }
		[DataType(DataType.DateTime)]
		public DateTime EmergencyDateTime { get; set; }
		[Required]
		public string? Description { get; set; }
		public string? Severity { get; set; }

        //Navigation property
        public Patient? Patient { get; set; }
        public Doctor? Doctor { get; set; }
        public Department? Department { get; set; }
		public EmergencyPrescribe? EmergencyPrescribe { get; set; }


	}
}
