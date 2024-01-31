using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Library.Models
{
	public class Shift
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ShiftID { get; set; }
		[Required]
		public string ShiftName { get; set; } //Morning,Afternoon,Night
		public TimeOnly StartTime { get; set; }
		public TimeOnly EndTime { get; set; }
		public bool ShiftStatus { get; set; } //Active or Inactive

		//Navigation Property

		//public Staff StaffID { get; set; }
		//public Department DepartmentID { get; set; }
		//public Room RoomID { get; set; }
		//public Nurse NurseID { get; set; }
		//public Doctor DoctorID { get; set; }
	}
}
