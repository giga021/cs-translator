using CsTranslator.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CsTranslator.Application.Services
{
	public interface ITranslateService
	{
		Task<TranslateResult> Translate(string query, string fromLanguage, string toLanguage);
	}
}
