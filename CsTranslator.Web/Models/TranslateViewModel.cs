using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CsTranslator.Web.Models
{
	public class TranslateViewModel
	{
		[Required(ErrorMessage = "Query is required")]
		public string TranslationQuery { get; set; }
		public string SourceLanguage { get; set; }
	}
}
