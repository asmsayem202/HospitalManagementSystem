
using System.Data.Common;
using System.Text;
using System.Text.Json.Serialization;
using FastReport.Data;
using HMS.Api.Services;
using HMS.Library.DAL;
using HMS.Library.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace HMS.Api
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddCors();


			builder.Services.AddDbContext<HMSdb>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));


			builder.Services
				.AddIdentity<ApplicationUser, IdentityRole>(options =>
				{
					options.SignIn.RequireConfirmedAccount = false;
					options.User.RequireUniqueEmail = true;
					options.Password.RequireDigit = false;
					options.Password.RequiredLength = 4;
					options.Password.RequireNonAlphanumeric = false;
					options.Password.RequireUppercase = false;
				})
			.AddRoles<IdentityRole>()
			.AddEntityFrameworkStores<HMSdb>();


			builder.Services.AddControllers().AddJsonOptions(options =>
			{
				options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
				//support string to enum converter
				options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
			});





			//builder.Services.AddControllers()
			//	//	.AddJsonOptions(options =>
			//	//{

			//	//	options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
			//	//	options.JsonSerializerOptions.PropertyNamingPolicy = null;
			//	//})
			//	;


			//builder.Services.Configure<JsonOptions>(opt =>
			//{
			//	opt.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
			//});


			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();

			builder.Services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "HMS API", Version = "v1" });

				c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				{
					Type = SecuritySchemeType.Http,
					BearerFormat = "JWT",
					In = ParameterLocation.Header,
					Scheme = "bearer",
					Description = "Please insert JWT token into field"
				});

				c.AddSecurityRequirement(new OpenApiSecurityRequirement
					{
						{
							new OpenApiSecurityScheme
							{
								Reference = new OpenApiReference
								{
									Type = ReferenceType.SecurityScheme,
									Id = "Bearer"
								}
							},
							new string[] { }
						}
					});
			});

			//builder.Services.AddTokenService();
			builder.Services.AddScoped<ITokenService, TokenService>();
			builder.Services.AddScoped<ImageUploadService>();



			var validIssuer = builder.Configuration.GetValue<string>("JwtTokenSettings:ValidIssuer");
			var validAudience = builder.Configuration.GetValue<string>("JwtTokenSettings:ValidAudience");
			var symmetricSecurityKey = builder.Configuration.GetValue<string>("JwtTokenSettings:SymmetricSecurityKey");

			builder.Services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
			})
				.AddJwtBearer(options =>
				{
					options.IncludeErrorDetails = true;
					options.UseSecurityTokenValidators = true;
					options.TokenValidationParameters = new TokenValidationParameters()
					{
						ClockSkew = TimeSpan.Zero,
						ValidateIssuer = true,
						ValidateAudience = true,
						ValidateLifetime = true,
						ValidateIssuerSigningKey = true,
						ValidIssuer = validIssuer,
						ValidAudience = validAudience,
						IssuerSigningKey = new SymmetricSecurityKey(
							Encoding.UTF8.GetBytes(symmetricSecurityKey)
						),
						SaveSigninToken = true
					};
				});


			FastReport.Utils.RegisteredObjects.AddConnection(typeof(MsSqlDataConnection));
			builder.Services.AddFastReport();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}
			app.UseStaticFiles();
			app.UseHttpsRedirection();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseCors(opt =>
			{
				opt.AllowAnyHeader();
				opt.AllowAnyOrigin();
				opt.AllowAnyMethod();
			});

			app.MapControllers();

			app.UseFastReport();

			app.Run();
		}
	}
}
