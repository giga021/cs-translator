using CsTranslator.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CsTranslator.Persistence.Context
{
	public class TranslatorDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
	{
		public TranslatorDbContext(DbContextOptions<TranslatorDbContext> options)
			: base(options)
		{

		}
	}
}
