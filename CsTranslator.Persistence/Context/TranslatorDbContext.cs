using CsTranslator.Domain.Entities;
using CsTranslator.Domain.Seedwork;
using CsTranslator.Persistence.EntityConfigurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace CsTranslator.Persistence.Context
{
	public class TranslatorDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>, IUnitOfWork
	{
		public TranslatorDbContext(DbContextOptions<TranslatorDbContext> options)
			: base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfiguration(new TranslationConfig());
		}

		public async Task SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			await SaveChangesAsync(cancellationToken);
		}
	}
}
