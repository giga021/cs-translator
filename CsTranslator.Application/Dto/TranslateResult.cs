using System;
using System.Collections.Generic;
using System.Text;

namespace CsTranslator.Application.Dto
{
	public class TranslateResult
	{
		public string TranslatedText { get; set; }
		public string FromLanguage { get; set; }
		public string ToLanguage { get; set; }

		public TranslateResult(string translatedText, string fromLanguage, string toLanguage)
		{
			TranslatedText = translatedText;
			FromLanguage = fromLanguage;
			ToLanguage = toLanguage;
		}
	}
}
