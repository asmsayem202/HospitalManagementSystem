using System.ComponentModel.DataAnnotations;

namespace HMS.Api.SecurityModels
{
	public class RegistrationRequest
	{
		[Required]
		public string? Email { get; set; }

		[Required]
		public string? Username { get; set; }

		[Required]
		public string? Password { get; set; }

		public IList<string> Role { get; set; } = [];
	}
}
