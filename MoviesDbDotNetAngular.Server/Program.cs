using MoviesDbDotNetAngular.Server.Common.Settings;
using MoviesDbDotNetAngular.Server.Connections.Interfaces;
using MoviesDbDotNetAngular.Server.Connections;
using MoviesDbDotNetAngular.Server.Common.Enums;
using Microsoft.AspNetCore.Authentication;
using MoviesDbDotNetAngular.Server.Handlers;


namespace MoviesDbDotNetAngular.Server
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			var environment = builder.Environment.EnvironmentName;
			var Configuration = new ConfigurationBuilder()
				.AddJsonFile("appsettings.json")
				.AddJsonFile("secrets.json", optional: true)
				.AddJsonFile($"appsettings.{environment}.json", optional: true)
				.AddEnvironmentVariables()
				.Build();

			builder.Services.AddControllers();
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Services.AddMemoryCache();
			builder.Services.AddLocalization(o => { o.ResourcesPath = "Resources"; });
			builder.Services.Configure<MySqlSettings>(
				options => Configuration
					.GetSection(SettingSection.MySqlSettings.ToString())
					.Bind(options)
			);
			builder.Services.AddScoped<IDatabaseConnectionFactory, MySqlConnectionFactory>();
			builder.Services.AddAuthentication("BasicAuthentication").AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

			var app = builder.Build();

			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseDefaultFiles();
			app.UseStaticFiles();
			//app.UseHttpsRedirection();
			app.UseAuthentication();
			app.UseAuthorization();
			app.MapControllers();
			app.UseRequestLocalization();
			app.MapFallbackToFile("/index.html");
			app.Run();
		}
	}
}
