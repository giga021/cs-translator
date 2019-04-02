using CsTranslator.Domain.Dto;
using CsTranslator.Domain.Entities;
using CsTranslator.Domain.Repositories;
using CsTranslator.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CsTranslator.Persistence.Repositories
{
	public class TranslationRepository : ITranslationRepository
	{
		private readonly TranslatorDbContext _context;

		public TranslationRepository(TranslatorDbContext context)
		{
			_context = context;
		}

		public void Add(Translation translation)
		{
			_context.Translations.Add(translation);
		}

		public async Task<IList<TranslationHistory>> ListHistory(string userId)
		{
			return await _context.Translations.Where(x => x.UserId == userId)
				.Select(x => new TranslationHistory
				{
					From = x.From,
					FromLanguage = x.FromLanguage,
					TimeStamp = x.TimeStamp,
					To = x.To,
					ToLanguage = x.ToLanguage
				}).OrderByDescending(x => x.TimeStamp).ToListAsync();
		}
	}
}
