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
	public class Ward
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int WardID { get; set; }
		[Required]
		public string? WardName { get; set; }
		public int? RoomId { get; set; }
		public int? NurseId { get; set; }
		public int? PatientId { get; set; }



        //Navigation Property
        [DeleteBehavior(DeleteBehavior.Cascade)]
        public virtual ICollection<Admission>? Admission { get; set; } = new List<Admission>();

        [DeleteBehavior(DeleteBehavior.Cascade)]
        public virtual ICollection<Patient>? Patient { get; set; } = new List<Patient>();

        [DeleteBehavior(DeleteBehavior.Cascade)]
        public virtual Nurse? Nurse { get; set; }

        [DeleteBehavior(DeleteBehavior.Cascade)]
        public virtual Room? Room { get; set; }
	}
}
