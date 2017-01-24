using System;
using System.Data.Common;
using System.Threading.Tasks;

namespace Bell.Database.Connections
{
    /// <summary>
    /// Represents a connection to the Bell database
    /// </summary>
    public interface IBellConnection
    {
        /// <summary>
        /// Runs the command specified and passes the db connection to this command
        /// </summary>
        /// <param name="command">The command to execute</param>
        /// <returns>The task associated with this asynchronous operation</returns>
        Task RunCommandAsync(Func<DbConnection, Task> command);

        /// <summary>
        /// Runs the command specified and passes the db connection to this command
        /// </summary>
        /// <typeparam name="TResult">The result of the command</typeparam>
        /// <param name="command">The command to execute</param>
        /// <returns>The result of the command</returns>
        Task<TResult> RunCommandAsync<TResult>(Func<DbConnection, Task<TResult>> command);
    }

    public class BellConnection : BaseConnection, IBellConnection
    {
        public BellConnection(string connectionString) : base(connectionString) { }
    }
}
