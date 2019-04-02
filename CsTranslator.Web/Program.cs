using CsTranslator.Persistence.Context;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;
using System;

namespace CsTranslator.Web
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Log.Logger = new LoggerConfiguration()
			   .MinimumLevel.Debug()
			   .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
			   .Enrich.FromLogContext()
			   .WriteTo.Console()
			   .WriteTo.RollingFile("translator.log")
			   .CreateLogger();

			try
			{
				Log.Information("Starting web host");
				var host = CreateWebHostBuilder(args).Build();
				InitializeDatabase(host);
				host.Run();
			}
			catch (Exception ex)
			{
				Log.Fatal(ex, "Host terminated unexpectedly");
			}
			finally
			{
				Log.CloseAndFlush();
			}
		}

		public static IWebHostBuilder CreateWebHostBuilder(string[] args)
		{
			return WebHost.CreateDefaultBuilder(args).UseStartup<Startup>().UseSerilog();
		}

		private static void InitializeDatabase(IWebHost host)
		{
			using (var scope = host.Services.CreateScope())
			{
				var services = scope.ServiceProvider;
				using (var context = services.GetRequiredService<TranslatorDbContext>())
				{
					context.Database.Migrate();
				}
			}
		}
	}
}
