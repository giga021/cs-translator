using CsTranslator.Domain.Repositories;
using CsTranslator.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CsTranslator.Web.Controllers
{
	public class HistoryController : Controller
	{
		private readonly ITranslationRepository _translationRepo;

		public HistoryController(ITranslationRepository translationRepo)
		{
			_translationRepo = translationRepo;
		}

		public async Task<IActionResult> Index()
		{
			var vm = new TranslationHistoryViewModel
			{
				History = await _translationRepo.ListHistory(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier))
			};
			return View(vm);
		}
	}
}
