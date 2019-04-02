using CsTranslator.Application.Queries;
using CsTranslator.Web.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace CsTranslator.Web.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TranslationsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public TranslationsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<ActionResult<TranslationResultDto>> Translate([FromQuery][Required]string translationQuery)
		{
			try
			{
				var result = await _mediator.Send(new TranslateQuery(translationQuery, null, null));
				var dto = new TranslationResultDto(result.TranslatedText);
				return Ok(dto);
			}
			catch (Exception exc)
			{
				return BadRequest(new TranslationResultDto { ErrorMessage = exc.Message });
			}
		}
	}
}