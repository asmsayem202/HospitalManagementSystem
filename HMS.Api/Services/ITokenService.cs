using HMS.Api.SecurityModels;
using HMS.Library.Models;

namespace HMS.Api.Services
{
	public interface ITokenService
	{
		string CreateToken(ApplicationUser user);
	}
}