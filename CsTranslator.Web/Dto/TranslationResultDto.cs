using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CsTranslator.Web.Dto
{
	public class TranslationResultDto
	{
		public string TranslatedText { get; set; }
		public string ErrorMessage { get; set; }

		public TranslationResultDto() { }

		public TranslationResultDto(string translatedText)
		{
			TranslatedText = translatedText;
		}
	}
}
