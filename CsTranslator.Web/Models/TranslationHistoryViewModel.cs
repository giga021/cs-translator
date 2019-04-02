using CsTranslator.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CsTranslator.Web.Models
{
	public class TranslationHistoryViewModel
	{
		public IList<TranslationHistory> History { get; set; }
	}
}
