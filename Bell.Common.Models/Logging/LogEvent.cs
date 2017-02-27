using System;

namespace Bell.Common.Models.Logging
{
    /// <summary>
    /// Represents a log event request
    /// </summary>
    public interface ILogEventRequest
    {
        /// <summary>
        /// The name of the application that created this log event
        /// </summary>
        string ApplicationName { get; set; }

        /// <summary>
        /// The machine name that triggered the log event
        /// </summary>
        string MachineName { get; set; }

        /// <summary>
        /// The process id associated with the log event
        /// </summary>
        int ProcessId { get; set; }

        /// <summary>
        /// The user id associated with the log event
        /// </summary>
        int? UserId { get; set; }

        /// <summary>
        /// The message template associated with the log event
        /// </summary>
        string MessageTemplate { get; set; }

        /// <summary>
        /// The message associated with the log event
        /// </summary>
        string Message { get; set; }

        /// <summary>
        /// The exception message associated with the log event
        /// </summary>
        string Exception { get; set; }

        /// <summary>
        /// The severity of the log event
        /// </summary>
        LogLevel Level { get; set; }

        /// <summary>
        /// The timestamp for when the log event occurred (in UTC)
        /// </summary>
        DateTime Timestamp { get; set; }
    }

    /// <summary>
    /// Represents a single log event
    /// </summary>
    public class LogEvent : ILogEventRequest
    {
        /// <summary>
        /// The id of the log event
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// The name of the application that created this log event
        /// </summary>
        public string ApplicationName { get; set; }

        /// <summary>
        /// The machine name that triggered the log event
        /// </summary>
        public string MachineName { get; set; }

        /// <summary>
        /// The process id associated with the log event
        /// </summary>
        public int ProcessId { get; set; }

        /// <summary>
        /// The user id associated with the log event
        /// </summary>
        public int? UserId { get; set; }

        /// <summary>
        /// The message template associated with the log event
        /// </summary>
        public string MessageTemplate { get; set; }

        /// <summary>
        ///The message associated with the log event
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The exception message associated with the log event
        /// </summary>
        public string Exception { get; set; }

        /// <summary>
        /// The severity of the log event
        /// </summary>
        public LogLevel Level { get; set; }

        /// <summary>
        /// The timestamp for when the log event occurred (in UTC)
        /// </summary>
        /// <remarks>This is the absolute timestamp, if set properly by the client</remarks>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// The server timestamp of the log event (in UTC)
        /// </summary>
        /// <remarks>Due to event batching, this is not an absolute timestamp</remarks>
        public DateTime ServerTimestamp { get; set; }
    }
}
