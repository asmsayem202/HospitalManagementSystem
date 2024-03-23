
using System.Data.Common;
using System.Text;
using System.Text.Json.Serialization;
using HMS.Api.Services;
using HMS.Library.DAL;
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


			builder.Services.AddIdentity<IdentityUser, IdentityRole>(
				//options => options.SignIn.RequireConfirmedAccount = true
				).AddEntityFrameworkStores<HMSdb>();


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


            builder.Services.AddAuthentication(opt =>
			{
				opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				//opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(opt =>
			{

				var key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:SignKey"]);
				//opt.SaveToken = true;
				opt.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(key),
					ValidateIssuer = false,
					ValidateAudience = false,
					RequireExpirationTime = true,
					ValidateLifetime = true,
				};
				opt.UseSecurityTokenValidators = true;
			});

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

			app.Run();
		}
	}
}
