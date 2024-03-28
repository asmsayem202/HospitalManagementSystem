using Microsoft.AspNetCore.Identity;

namespace HMS.Library.Models
{
	public class ApplicationUser : IdentityUser
	{
		public IList<string> Role { get; set; } = [];
	}

}
public class UserRoleDto
{
	public string? Id { get; set; }
	public string Name { get; set; }
}

public class AssignRoleDto
{
    public string Id { get; set; }
    public string UserName { get; set; }
    public IList<string> Role { get; set; } = [];
}