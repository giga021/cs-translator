using System;
using System.Collections.Generic;
using System.Text;

namespace CsTranslator.Domain.Dto
{
	public class TranslationHistory
	{
		public DateTime TimeStamp { get; set; }
		public string FromLanguage { get; set; }
		public string ToLanguage { get; set; }
		public string From { get; set; }
		public string To { get; set; }
	}
}
