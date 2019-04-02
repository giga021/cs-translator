using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;

namespace CsTranslator.Persistence.Context
{
	public class TranslatorDbContextFactory : IDesignTimeDbContextFactory<TranslatorDbContext>
	{
		public TranslatorDbContext CreateDbContext(string[] args)
		{
			IConfigurationRoot config = new ConfigurationBuilder()
			   .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
			   .AddJsonFile("appsettings.Migrations.json", optional: false)
			   .AddEnvironmentVariables()
			   .Build();

			var optionsBuilder = new DbContextOptionsBuilder<TranslatorDbContext>();
			optionsBuilder.UseSqlServer(config["ConnectionString"]);

			return new TranslatorDbContext(optionsBuilder.Options);
		}
	}
}
