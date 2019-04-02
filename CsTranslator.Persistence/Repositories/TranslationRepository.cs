using CsTranslator.Domain.Entities;
using CsTranslator.Domain.Repositories;
using CsTranslator.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;

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
	}
}
