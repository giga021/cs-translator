using Autofac;
using CsTranslator.Application.Queries.Translate;
using MediatR;
using System.Reflection;

namespace CsTranslator.Web.AutofacModules
{
	public class MediatrModule : Autofac.Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
				.AsImplementedInterfaces().InstancePerLifetimeScope();

			builder.RegisterAssemblyTypes(typeof(TranslateQueryHandler).GetTypeInfo().Assembly)
				.AsClosedTypesOf(typeof(IRequestHandler<,>)).InstancePerLifetimeScope();

			builder.Register<ServiceFactory>(ctx =>
			{
				var c = ctx.Resolve<IComponentContext>();
				return t => c.Resolve(t);
			});
		}
	}
}
