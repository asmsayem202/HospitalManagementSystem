namespace HMS.Api.SecurityModels
{
	public class AuthResponse
	{
		public string? Username { get; set; }
		public string? Email { get; set; }
		public string? Token { get; set; }
		public string[] Roles { get; set; } = [];
	}
}
