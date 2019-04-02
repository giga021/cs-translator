using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CsTranslator.Web.Models;
using Microsoft.Extensions.Options;
using CsTranslator.Application;

namespace CsTranslator.Web.Controllers
{
	public class HomeController : Controller
	{
		private readonly IOptions<AppSettings> _appSettings;

		public HomeController(IOptions<AppSettings>appSettings)
		{
			_appSettings = appSettings;
		}

		public IActionResult Index()
		{
			var vm = new TranslateViewModel
			{
				SourceLanguage = _appSettings.Value.DefaultLanguageInput
			};
			return View(vm);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
