using System;

namespace CsTranslator.Domain.Entities
{
	public class Translation
	{
		public long Id { get; set; }
		public DateTime TimeStamp { get; set; }
		public string FromLanguage { get; set; }
		public string ToLanguage { get; set; }
		public string From { get; set; }
		public string To { get; set; }

		public string UserId { get; set; }
		public ApplicationUser User { get; set; }
	}
}
