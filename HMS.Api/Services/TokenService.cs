using HMS.Api.SecurityModels;
using HMS.Library.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HMS.Api.Services
{
	public class TokenService : ITokenService
	{
		private const int ExpirationDays = 7;
		private readonly ILogger<TokenService> _logger;

		public TokenService(ILogger<TokenService> logger)
		{
			_logger = logger;
		}

		public string CreateToken(ApplicationUser user)
		{

			var token = CreateJwtToken(user);

			//var payload = new JObject()
			//{
			//    { JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()},
			//    { JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString()},
			//    { JwtRegisteredClaimNames.Exp, expiration.ToUnixTimeSeconds().ToString()},
			//    { JwtRegisteredClaimNames.Email, user.Email },
			//    { JwtRegisteredClaimNames.GivenName,user.UserName},
			//    { JwtRegisteredClaimNames.Name,user.UserName},
			//    { ClaimTypes.NameIdentifier, user.Id },
			//    { ClaimTypes.Role, user.Role.ToString() }
			//}.ToString();

			//var tokenHandler = new JsonWebTokenHandler();
			//var signingCredentials = CreateSigningCredentials();
			//var jwt = tokenHandler.CreateToken(payload);
			var tokenHandler = new JwtSecurityTokenHandler();
			_logger.LogInformation("JWT Token created");

			return tokenHandler.WriteToken(token);
		}

		private JwtSecurityToken CreateJwtToken(ApplicationUser user)
		{
			var expiration = DateTime.UtcNow.AddDays(ExpirationDays);
			var claims = CreateClaims(user);
			var credentials = CreateSigningCredentials();

			return new JwtSecurityToken(
				new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("JwtTokenSettings")["ValidIssuer"],
				new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("JwtTokenSettings")["ValidAudience"],
				claims,
				expires: expiration,
				signingCredentials: credentials
			);
		}
		//yyyyMMddHHmmss
		private List<Claim> CreateClaims(ApplicationUser user)
		{
			var jwtSub = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("JwtTokenSettings")["JwtRegisteredClaimNamesSub"];

			try
			{
				var claims = new List<Claim>
					{
						new Claim(JwtRegisteredClaimNames.Sub, jwtSub),
						new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
						new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString()),
						new Claim(ClaimTypes.NameIdentifier, user.Id),
						new Claim(ClaimTypes.Name, user.UserName),
						new Claim(ClaimTypes.Email, user.Email),
						//new Claim(ClaimTypes.Role, string.Join(',',user.Role))
					};


				foreach (var role in user.Role)
				{
					claims.Add(new Claim(ClaimTypes.Role, role));
				}

				return claims;
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		private SigningCredentials CreateSigningCredentials()
		{
			var symmetricSecurityKey = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("JwtTokenSettings")["SymmetricSecurityKey"];

			return new SigningCredentials(
				new SymmetricSecurityKey(
					Encoding.UTF8.GetBytes(symmetricSecurityKey)
				),
				SecurityAlgorithms.HmacSha256
			);
		}
	}
}