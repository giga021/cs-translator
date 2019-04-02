using CsTranslator.Application.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CsTranslator.Web.Services
{
	public class IdentityService : IIdentityService
	{
		private readonly IHttpContextAccessor _httpContextAccessor;
		public IdentityService(IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
		}

		public string GetUserId()
		{
			return _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
		}
	}
}
