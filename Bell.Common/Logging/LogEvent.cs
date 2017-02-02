﻿using Newtonsoft.Json;
using System;
using Bell.Common.Json;

namespace Bell.Common.Logging
{
    [JsonConverter(typeof(JsonInterfaceResolver<ILogEventRequest>))]
    public interface ILogEventRequest
    {
        /// <summary>
        /// Gets or sets the name of the application that created this log event
        /// </summary>
        string ApplicationName { get; set; }

        /// <summary>
        /// Gets or sets the machine name that triggered the log event
        /// </summary>
        string MachineName { get; set; }

        /// <summary>
        /// Gets or sets the process id associated with the log event
        /// </summary>
        int ProcessId { get; set; }

        /// <summary>
        /// Gets or sets the user id associated with the log event
        /// </summary>
        int? UserId { get; set; }

        /// <summary>
        /// Gets or sets the message template associated with the log event
        /// </summary>
        string MessageTemplate { get; set; }

        /// <summary>
        /// Gets or sets the message associated with the log event
        /// </summary>
        string Message { get; set; }

        /// <summary>
        /// Gets or sets any exception messages associated with the log event
        /// </summary>
        string Exception { get; set; }

        /// <summary>
        /// Gets or sets the severity of the log event
        /// </summary>
        LogLevel Level { get; set; }

        /// <summary>
        /// Gets or sets the timestamp for when the log event occurred (in UTC)
        /// </summary>
        DateTime Timestamp { get; set; }
    }

    /// <summary>
    /// Represents a single log event
    /// </summary>
    public class LogEvent : ILogEventRequest
    {
        /// <summary>
        /// Gets or sets the id of the log event
        /// </summary>
        public long Id { get; set; }

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

        /// <summary>
        /// Gets or sets the timestamp for when the log event occurred (in UTC)
        /// </summary>
        /// <remarks>This is the absolute timestamp, if set properly by the client</remarks>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the server timestamp of the log event (in UTC)
        /// </summary>
        /// <remarks>Due to event batching, this is not an absolute timestamp</remarks>
        public DateTime ServerTimestamp { get; set; }
    }
}
