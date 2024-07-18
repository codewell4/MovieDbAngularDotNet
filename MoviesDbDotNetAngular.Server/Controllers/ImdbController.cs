using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using MoviesDbDotNetAngular.Server.Connections.Interfaces;
using MoviesDbDotNetAngular.Server.DTOs;
using MoviesDbDotNetAngular.Server.Services;
using MoviesDbDotNetAngular.Server.Services.Interfaces;

namespace MoviesDbDotNetAngular.Server.Controllers
{
    [ApiController]
	[Route("[controller]")]
	public class ImdbController : ControllerBase
	{
		private readonly IImdbService _imdbService;

		public ImdbController(IDatabaseConnectionFactory connectionFactory, IMemoryCache memoryCache)
		{
			_imdbService = new ImdbService(connectionFactory, memoryCache);
		}

		[AllowAnonymous]
		[HttpGet("List")]
		public async Task<IEnumerable<ImdbEntityDto>> List(int page = 1, int offset = 5)
		{
			return await _imdbService.GetEntitiesAsync(page, offset);
		}

		[AllowAnonymous]
		[HttpGet("Search")]
		public async Task<IEnumerable<ImdbEntityDto>> Search(string query)
		{
			return await _imdbService.SearchEntitiesAsync(query);
		}

		[Authorize(Roles = "Admin")]
		[HttpPost("Edit")]
		public async Task<bool> Edit([FromBody] TitleEntityDto entity)
		{
			return await _imdbService.EditTitleAsync(entity.ImdbId, entity.Title);
		}

		[Authorize]
		[HttpPost("Favourite")]
		public async Task<bool> Favorite(string imdbId)
		{
			return await _imdbService.AddFavorite(imdbId);
		}

		[Authorize]
		[HttpPost("Watch")]
		public async Task<bool> Watch(string imdbId)
		{
			return await _imdbService.AddWatch(imdbId);
		}

		[AllowAnonymous]
		[HttpGet("Translations")]
		public async Task<IEnumerable<string>> Translations(string language)
		{
			//External (proxy) API call for translations (ie: poeditor.com) + caching
			return null;
		}
	}
}
