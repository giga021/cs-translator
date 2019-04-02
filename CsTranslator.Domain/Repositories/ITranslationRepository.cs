using CsTranslator.Domain.Dto;
using CsTranslator.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CsTranslator.Domain.Repositories
{
	public interface ITranslationRepository
	{
		void Add(Translation translation);
		Task<IList<TranslationHistory>> ListHistory(string userId);
	}
}
