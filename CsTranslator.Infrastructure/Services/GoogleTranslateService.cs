using CsTranslator.Application.Dto;
using CsTranslator.Application.Services;
using Google.Cloud.Translation.V2;
using System;
using System.Threading.Tasks;

namespace CsTranslator.Infrastructure.Services
{
	public class GoogleTranslateService : ITranslateService
	{
		private readonly TranslationClient _client;

		public GoogleTranslateService(TranslationClient client)
		{
			_client = client;
		}

		public async Task<TranslateResult> Translate(string query, string fromLanguage, string toLanguage)
		{
			if (string.IsNullOrEmpty(query))
				throw new ArgumentNullException(nameof(query));
			if (string.IsNullOrEmpty(fromLanguage))
				throw new ArgumentNullException(nameof(fromLanguage));
			if (string.IsNullOrEmpty(toLanguage))
				throw new ArgumentNullException(nameof(toLanguage));

			var response = await _client.TranslateTextAsync(
				text: query,
				targetLanguage: toLanguage,
				sourceLanguage: fromLanguage);
			return new TranslateResult(response.TranslatedText,
				response.DetectedSourceLanguage ?? response.SpecifiedSourceLanguage,
				response.TargetLanguage);
		}
	}
}
