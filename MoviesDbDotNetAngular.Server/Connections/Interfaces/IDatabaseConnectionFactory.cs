using System.Data.Common;

namespace MoviesDbDotNetAngular.Server.Connections.Interfaces
{
	public interface IDatabaseConnectionFactory
	{
		DbConnection GetConnection();
	}
}
