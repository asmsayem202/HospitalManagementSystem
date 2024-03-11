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
	public class Shift
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ShiftId { get; set; }
		[Required]
		public ShiftSlot ShiftName { get; set; } //Morning,Afternoon,Night
		public TimeOnly StartTime { get; set; }
		public TimeOnly EndTime { get; set; }
		public bool ShiftStatus { get; set; } //Active or Inactive
		public int? StaffID { get; set; }
		public int? NurseID { get; set; }
		public int? DoctorID { get; set; }


        //Navigation Property
        public Staff? Staff { get; set; }

        public Nurse? Nurse { get; set; }

        public Doctor? Doctor { get; set; }
	}

	public enum ShiftSlot
	{
		Morning, Afternoon, Night
	}
}
