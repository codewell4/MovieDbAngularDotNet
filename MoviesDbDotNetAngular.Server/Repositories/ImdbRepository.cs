using MoviesDbDotNetAngular.Server.Connections.Interfaces;
using MoviesDbDotNetAngular.Server.Models;
using MoviesDbDotNetAngular.Server.Repositories.Interfaces;
using SqlKata.Compilers;
using SqlKata.Execution;

namespace MoviesDbDotNetAngular.Server.Repositories
{
	public class ImdbRepository : IImdbRepository
	{
		private readonly IDatabaseConnectionFactory _connectionFactory;

		public ImdbRepository(IDatabaseConnectionFactory connectionFactory)
		{
			_connectionFactory = connectionFactory;
		}

		public async Task<PaginationResult<ImdbEntity>> GetEntitiesAsync(int page, int limit)
		{
			using (var connection = _connectionFactory.GetConnection())
			{
				var compiler = new MySqlCompiler();
				var queryFactory = new QueryFactory(connection, compiler);

				try
				{
					return await queryFactory
						.Query("ImdbEntity")
						.Select(
							"Id",
							"ImdbId",
							"Title",
							"ImageUrl",
							"Created",
							"Modified"
						)
						.OrderBy("title")
						.PaginateAsync<ImdbEntity>(page, limit);
				}
				catch (Exception ex)
				{
					Console.Error.Write(ex);
					Console.Error.Close();
					throw;
				}
			}
		}

		public async Task<IEnumerable<ImdbEntity>> SearchEntitiesAsync(string query)
		{
			using (var connection = _connectionFactory.GetConnection())
			{
				var compiler = new MySqlCompiler();
				var queryFactory = new QueryFactory(connection, compiler);

				try
				{
					return await queryFactory
						.Query("ImdbEntity")
						.Select(
							"Id",
							"ImdbId",
							"Title",
							"ImageUrl",
							"Created",
							"Modified"
						)
						.WhereLike("ImdbId", $"%{query}%")
						.OrWhereLike("Title", $"%{query}%")
						.OrderBy("title")
						.GetAsync<ImdbEntity>();
				}
				catch (Exception ex)
				{
					Console.Error.Write(ex);
					Console.Error.Close();
					throw;
				}
			}
		}

		public async Task<int> EditTitleAsync(string imdbId, string title)
		{
			using (var connection = _connectionFactory.GetConnection())
			{
				var compiler = new MySqlCompiler();
				var queryFactory = new QueryFactory(connection, compiler);

				try
				{
					return await queryFactory.Query("ImdbUser")
						.UpdateAsync(new
						{
							ImdbId = imdbId,
							Title = title,
							Modified = DateTime.Now
						});
				}
				catch (Exception ex)
				{
					Console.Error.Write(ex);
					Console.Error.Close();
					throw;
				}
			}
		}

		public async Task<int> AddFavorite(string imdbId)
		{
			throw new NotImplementedException();
		}

		public async Task<int> AddWatch(string imdbId)
		{
			throw new NotImplementedException();
		}
	}
}
