using CsTranslator.Web.Dto;
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
		[HttpGet]
		public async Task<ActionResult<TranslationResultDto>> Translate([FromQuery][Required]string translationQuery)
		{
			return Ok(new TranslationResultDto(DateTime.Now.Ticks.ToString()));
		}
	}
}