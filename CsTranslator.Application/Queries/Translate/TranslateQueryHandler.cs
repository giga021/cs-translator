using CsTranslator.Application.Dto;
using CsTranslator.Application.Services;
using CsTranslator.Domain.Entities;
using CsTranslator.Domain.Repositories;
using CsTranslator.Domain.Seedwork;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CsTranslator.Application.Queries.Translate
{
	public class TranslateQueryHandler : IRequestHandler<TranslateQuery, TranslateResult>
	{
		private readonly IOptions<AppSettings> _settings;
		private readonly ITranslateService _translateSvc;
		private readonly ITranslationRepository _translateRepo;
		private readonly IUnitOfWork _uow;
		private readonly IIdentityService _identitySvc;

		public TranslateQueryHandler(IOptions<AppSettings> settings, ITranslateService translateSvc, ITranslationRepository translateRepo,
			IUnitOfWork uow, IIdentityService identitySvc)
		{
			_settings = settings;
			_translateSvc = translateSvc;
			_translateRepo = translateRepo;
			_uow = uow;
			_identitySvc = identitySvc;
		}

		public async Task<TranslateResult> Handle(TranslateQuery request, CancellationToken cancellationToken)
		{
			var result = await _translateSvc.Translate(request.Query,
				request.SourceLanguage ?? _settings.Value.DefaultLanguageInput,
				request.TargetLanguage ?? _settings.Value.DefaultLanguageOutput);
			var translation = new Translation
			{
				From = request.Query,
				To = result.TranslatedText,
				FromLanguage = result.FromLanguage.ToUpper(),
				ToLanguage = result.ToLanguage.ToUpper(),
				TimeStamp = DateTime.UtcNow,
				UserId = _identitySvc.GetUserId()
			};
			_translateRepo.Add(translation);
			await _uow.SaveEntitiesAsync();
			return result;
		}
	}
}
