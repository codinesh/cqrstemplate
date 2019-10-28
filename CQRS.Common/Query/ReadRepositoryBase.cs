using MySql.Data.MySqlClient;

namespace CQRS.Common
{
    public abstract class ReadRepositoryBase : IReadRepository
    {
        private MySqlConnection connection;
        private readonly string connectionString;

        public ReadRepositoryBase(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public MySqlConnection GetConnection()
        {
            if (connection != null)
            {
                return connection;
            }

            connection = new MySqlConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}
