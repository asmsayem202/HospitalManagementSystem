using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Library.Models
{
	public class Room
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int RoomId { get; set; }
		[Required]
		public string RoomNumber { get; set; }
		public string? Status { get; set; } //Occupied,Availabe

		public int? WardID { get; set; }
		//Navigation Property
		public Ward? Ward { get; set; }
	}
}
