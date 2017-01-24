using System;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Bell.Database.Connections
{
    /// <summary>
    /// A base class for DB connections
    /// </summary>
    public abstract class BaseConnection
    {
        #region Constructors

        /// <summary>
        /// Instantiates a DB connection handler
        /// </summary>
        /// <param name="connectionString">The connection string</param>
        protected BaseConnection(string connectionString)
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// The name of the connection string
        /// </summary>
        public string ConnectionString { get; private set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Runs the command specified and passes the db connection to this command
        /// </summary>
        /// <param name="command">The command to execute</param>
        /// <returns>The task associated with this asynchronous operation</returns>
        public async Task RunCommandAsync(Func<DbConnection, Task> command)
        {
            using (DbConnection connection = CreateConnection())
            {
                connection.Open();
                await command(connection);
                connection.Close();
            }
        }

        /// <summary>
        /// Runs the command specified and passes the db connection to this command
        /// </summary>
        /// <typeparam name="TResult">The result of the command</typeparam>
        /// <param name="command">The command to execute</param>
        /// <returns>The result of the command</returns>
        public async Task<TResult> RunCommandAsync<TResult>(Func<DbConnection, Task<TResult>> command)
        {
            TResult result;

            using (DbConnection connection = CreateConnection())
            {
                connection.Open();
                result = await command(connection);
                connection.Close();
            }

            return result;
        }

        #endregion

        #region Private Methods

        private DbConnection CreateConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        #endregion
    }
}
