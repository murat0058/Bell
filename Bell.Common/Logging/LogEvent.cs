using System;

namespace Bell.Common.Logging
{
    public class LogEventRequest
    {
        /// <summary>
        /// Gets or sets the name of the application that created this log event
        /// </summary>
        public string ApplicationName { get; set; }

        /// <summary>
        /// Gets or sets the machine name that triggered the log event
        /// </summary>
        public string MachineName { get; set; }

        /// <summary>
        /// Gets or sets the process id associated with the log event
        /// </summary>
        public int ProcessId { get; set; }

        /// <summary>
        /// Gets or sets the user id associated with the log event
        /// </summary>
        public int? UserId { get; set; }

        /// <summary>
        /// Gets or sets the message template associated with the log event
        /// </summary>
        public string MessageTemplate { get; set; }

        /// <summary>
        /// Gets or sets the message associated with the log event
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets any exception messages associated with the log event
        /// </summary>
        public string Exception { get; set; }

        /// <summary>
        /// Gets or sets the severity of the log event
        /// </summary>
        public LogLevel Level { get; set; }
    }

    /// <summary>
    /// Represents a single log event
    /// </summary>
    public class LogEvent : LogEventRequest
    {
        /// <summary>
        /// Gets or sets the id of the log event
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the timestamp of the log event (in UTC)
        /// </summary>
        /// <remarks>Due to event batching, this is not an absolute timestamp</remarks>
        public DateTime Timestamp { get; set; }
    }
}
