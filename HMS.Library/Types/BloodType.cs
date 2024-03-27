using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using HMS.Library.Models;
using Microsoft.EntityFrameworkCore;

namespace HMS.Library.Types
{
	public class BloodType
	{
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BloodTypeId { get; set; }
        public string Name { get; set; }

        //Navigation property
		public ICollection<Patient>? Patient { get; set; } = new List<Patient>();
	}
}
