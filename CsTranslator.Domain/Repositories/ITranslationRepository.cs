using CsTranslator.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CsTranslator.Domain.Repositories
{
	public interface ITranslationRepository
	{
		void Add(Translation translation);
	}
}
