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
		public int WardId { get; set; }
		[Required]
		public string Name { get; set; }



		//Navigation Property

		public ICollection<Nurse>? Nurses { get; set; } = new List<Nurse>();

        public ICollection<Room>? Rooms { get; set; } = new List<Room>();


	}
}
