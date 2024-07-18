using Microsoft.Extensions.Options;
using MoviesDbDotNetAngular.Server.Common.Settings;
using MoviesDbDotNetAngular.Server.Connections.Interfaces;
using MySql.Data.MySqlClient;
using System.Data.Common;

namespace MoviesDbDotNetAngular.Server.Connections
{
	public class MySqlConnectionFactory : IDatabaseConnectionFactory
	{
		private readonly DbConnectionStringBuilder _connectionStringBuilder;

		public MySqlConnectionFactory(IOptions<MySqlSettings> mySqlSettings)
		{
			_connectionStringBuilder = new DbConnectionStringBuilder
			{
				{ "server", mySqlSettings.Value.Server },
				{ "uid", mySqlSettings.Value.Username },
				{ "password", mySqlSettings.Value.Password },
				{ "database", mySqlSettings.Value.Database },
			};
		}

		public DbConnection GetConnection()
		{
			var connectionString = _connectionStringBuilder.ConnectionString;

			return new MySqlConnection(connectionString);
		}
	}
}
