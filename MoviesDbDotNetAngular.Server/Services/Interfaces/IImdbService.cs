using MoviesDbDotNetAngular.Server.DTOs;

namespace MoviesDbDotNetAngular.Server.Services.Interfaces
{
	public interface IImdbService
	{
		Task<IEnumerable<ImdbEntityDto>> GetEntitiesAsync(int page, int limit);
		Task<IEnumerable<ImdbEntityDto>> SearchEntitiesAsync(string query);
		Task<bool> EditTitleAsync(string imdbId, string title);
		Task<bool> AddFavorite(string imdbId);
		Task<bool> AddWatch(string imdbId);
	}
}
