using Autofac;
using CsTranslator.Application;
using CsTranslator.Application.Services;
using CsTranslator.Domain.Seedwork;
using CsTranslator.Infrastructure.Services;
using CsTranslator.Persistence.Context;
using Google.Cloud.Translation.V2;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Options;
using System;

namespace CsTranslator.Web.AutofacModules
{
	public class ApplicationModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.Register(c =>
			{
				var appSettings = c.Resolve<IOptions<AppSettings>>().Value;
				var optionsBuilder = new DbContextOptionsBuilder<TranslatorDbContext>();
				optionsBuilder.ConfigureWarnings(x => x.Throw(RelationalEventId.QueryClientEvaluationWarning));
				optionsBuilder.UseSqlServer(appSettings.ConnectionString, sqlOptions =>
				{
					sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
					sqlOptions.MigrationsAssembly(typeof(TranslatorDbContext).Assembly.FullName);
				});
				return optionsBuilder.Options;
			}).SingleInstance();
			builder.RegisterType<TranslatorDbContext>().InstancePerLifetimeScope().AsSelf().As<IUnitOfWork>();

			builder.Register(c => TranslationClient.CreateFromApiKey(c.Resolve<IOptions<AppSettings>>().Value.GoogleTranslateKey)).SingleInstance();
			builder.RegisterType<GoogleTranslateService>().As<ITranslateService>();
		}
	}
}
