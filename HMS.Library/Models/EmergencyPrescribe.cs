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
	public class EmergencyPrescribe
	{
		[Key]		
		[ForeignKey(nameof(Emergency))]
		public int? EmergencyID { get; set; }
		[Required]
		public string Symptoms { get; set; }

		
		[Required]
		[DataType(DataType.DateTime)]
		public DateTime FollowupDate { get; set; }

		public string? FollowupNotes { get; set; }


		//Navigation Property
		public Emergency? Emergency { get; set; }

        public List<EmergencyPrescribeDetails>? EmergencyPrescribeDetails { get; set; } = default;

    }

    public class EmergencyPrescribeDetails
	{
        [Key]
        public int EmergencyPrescribeDetailsId { get; set; }

        [ForeignKey(nameof(EmergencyPrescribe))]
        public int EmergencyID { get; set; }

        [Required]
        public string Medication { get; set; }
        [Required]
        public string Dosgae { get; set; }
        public string? Instructions { get; set; }
        public EmergencyPrescribe? EmergencyPrescribe { get; set; }

    }

}
