using CsTranslator.Application.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CsTranslator.Application.Queries
{
	public class TranslateQuery : IRequest<TranslateResult>
	{
		public string Query { get; }
		public string SourceLanguage { get; }
		public string TargetLanguage { get; }

		public TranslateQuery(string query, string sourceLanguage, string targetLanguage)
		{
			Query = query;
			SourceLanguage = sourceLanguage;
			TargetLanguage = targetLanguage;
		}
	}
}
