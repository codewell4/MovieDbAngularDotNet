using Microsoft.Extensions.Caching.Memory;
using MoviesDbDotNetAngular.Server.Common;
using MoviesDbDotNetAngular.Server.Connections.Interfaces;
using MoviesDbDotNetAngular.Server.DTOs;
using MoviesDbDotNetAngular.Server.Repositories;
using MoviesDbDotNetAngular.Server.Repositories.Interfaces;
using MoviesDbDotNetAngular.Server.Services.Interfaces;

namespace MoviesDbDotNetAngular.Server.Services
{
	public class ImdbService : IImdbService
	{
		private readonly IImdbRepository _imdbRepository;
		private readonly IMemoryCache _memoryCache;

		public ImdbService(IDatabaseConnectionFactory connectionFactory, IMemoryCache memoryCache)
		{
			_imdbRepository = new ImdbRepository(connectionFactory);
			_memoryCache = memoryCache;
		}

		public async Task<IEnumerable<ImdbEntityDto>> GetEntitiesAsync(int page, int limit)
		{
			var cacheKey = string.Format(CacheKeyList.FirstPageList, page, limit);
			
			// TODO: replace this with more viable option -> Redis
			if (!_memoryCache.TryGetValue(cacheKey, out IEnumerable<ImdbEntityDto> resultSet))
			{
				resultSet = ImdbEntityDto.FromImdbEntity(await _imdbRepository.GetEntitiesAsync(page, limit));
				if (resultSet != null)
				{
					var cacheEntryOptions = new MemoryCacheEntryOptions
					{
						AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(CacheKeyList.DefaultRelativeExpirationTimeMinutes)
					};

					_memoryCache.Set(cacheKey, resultSet, cacheEntryOptions);
				}
			}

			return resultSet;
		}

		public async Task<IEnumerable<ImdbEntityDto>> SearchEntitiesAsync(string query)
		{
			return ImdbEntityDto.FromImdbEntity(await _imdbRepository.SearchEntitiesAsync(query));
		}

		public async Task<bool> EditTitleAsync(string imdbId, string title)
		{
			return await _imdbRepository.EditTitleAsync(imdbId, title) > 0 ? true : false;
		}

		public async Task<bool> AddFavorite(string imdbId)
		{
			return await _imdbRepository.AddFavorite(imdbId) > 0 ? true : false;
		}

		public async Task<bool> AddWatch(string imdbId)
		{
			return await _imdbRepository.AddWatch(imdbId) > 0 ? true : false;
		}
	}
}
