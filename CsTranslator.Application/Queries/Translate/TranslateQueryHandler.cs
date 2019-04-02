using CsTranslator.Application.Dto;
using CsTranslator.Application.Services;
using MediatR;
using Microsoft.Extensions.Options;
using System.Threading;
using System.Threading.Tasks;

namespace CsTranslator.Application.Queries.Translate
{
	public class TranslateQueryHandler : IRequestHandler<TranslateQuery, TranslateResult>
	{
		private readonly IOptions<AppSettings> _settings;
		private readonly ITranslateService _translateSvc;

		public TranslateQueryHandler(IOptions<AppSettings> settings, ITranslateService translateSvc)
		{
			_settings = settings;
			_translateSvc = translateSvc;
		}

		public async Task<TranslateResult> Handle(TranslateQuery request, CancellationToken cancellationToken)
		{
			var result = await _translateSvc.Translate(request.Query,
				request.SourceLanguage ?? _settings.Value.DefaultLanguageInput,
				request.TargetLanguage ?? _settings.Value.DefaultLanguageOutput);
			return result;
		}
	}
}
