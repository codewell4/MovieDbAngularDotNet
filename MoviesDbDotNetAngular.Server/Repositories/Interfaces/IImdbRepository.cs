using MoviesDbDotNetAngular.Server.Models;
using SqlKata.Execution;

namespace MoviesDbDotNetAngular.Server.Repositories.Interfaces
{
	public interface IImdbRepository
	{
		Task<PaginationResult<ImdbEntity>> GetEntitiesAsync(int page, int limit);
		Task<IEnumerable<ImdbEntity>> SearchEntitiesAsync(string query);
		Task<int> EditTitleAsync(string imdbId, string title);
		Task<int> AddFavorite(string imdbId);
		Task<int> AddWatch(string imdbId);
	}
}
