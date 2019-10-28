using MySql.Data.MySqlClient;

namespace CQRS.Common.Commands
{
    public interface IUnitOfWork
    {
        MySqlConnection GetConnection();

        MySqlTransaction GetTransaction();

        void CommitChanges();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private MySqlConnection connection;
        private MySqlTransaction transaction;
        private readonly string connectionString;

        public UnitOfWork(string connectionString)
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
            transaction = connection.BeginTransaction();
            return connection;
        }

        public MySqlTransaction GetTransaction()
        {
            return this.transaction;
        }

        public void CommitChanges()
        {
            try
            {
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
            finally
            {
                transaction.Dispose();
                connection.Close();
            }
        }
    }
}
