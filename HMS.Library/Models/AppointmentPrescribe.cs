using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HMS.Library.Models
{
	public class AppointmentPrescribe
	{
		[Key]
		[ForeignKey(nameof(Appointment))]
		public int AppointmentID { get; set; }
		[Required]
		public string Symptoms { get; set; }

		
		[Required]
		[DataType(DataType.DateTime)]
		public DateTime FollowupDate { get; set; }

		public string? FollowupNotes { get; set; }


		//Navigation Property
		public Appointment? Appointment { get; set; }

		public List<AppointmentPrescribeDetails>? AppointmentPrescribeDetails { get; set; } = default;
	}

	public class AppointmentPrescribeDetails
	{
		[Key]
		public int AppointmentPrescribeDetailsId { get; set; }

		[ForeignKey(nameof(AppointmentPrescribe))]
		public int AppointmentID { get; set; }
		
		[Required]
		public string Medication { get; set; }
		[Required]
		public string Dosgae { get; set; }
		public string? Instructions { get; set; }

		public AppointmentPrescribe? AppointmentPrescribe { get; set; }
	}

}
