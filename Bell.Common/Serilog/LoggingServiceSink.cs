using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bell.Common.Models;
using Bell.Common.Services;
using Serilog.Events;
using Serilog.Sinks.PeriodicBatching;
using LogEvent = Bell.Common.Models.LogEvent;
using SerilogLogEvent = Serilog.Events.LogEvent;
using SerilogLogEventLevel = Serilog.Events.LogEventLevel;

namespace Bell.Common.Serilog
{
    /// <summary>
    /// Write log events to the logging service.
    /// </summary>
    public sealed class LoggingServiceSink : PeriodicBatchingSink
    {
        #region Private Fields

        private readonly string _applicationName;
        private readonly ILogEventWriter _logEventWriter;
        private readonly IDictionary<SerilogLogEventLevel, LogLevel> _logLevelMap;

        #endregion

        #region Constructor

        public LoggingServiceSink(ILogEventWriter logEventWriter, string applicationName, int batchPostingLimit, TimeSpan period)
            : base(batchPostingLimit, period)
        {
            _logEventWriter = logEventWriter;
            _applicationName = applicationName;

            _logLevelMap = new Dictionary<SerilogLogEventLevel, LogLevel>
            {
                { SerilogLogEventLevel.Verbose, LogLevel.Verbose },
                { SerilogLogEventLevel.Debug, LogLevel.Debug },
                { SerilogLogEventLevel.Information, LogLevel.Information },
                { SerilogLogEventLevel.Warning, LogLevel.Warning },
                { SerilogLogEventLevel.Error, LogLevel.Error },
                { SerilogLogEventLevel.Fatal, LogLevel.Fatal }
            };
        }

        #endregion

        #region Public Methods

        protected override async Task EmitBatchAsync(IEnumerable<SerilogLogEvent> serilogLogEvents)
        {
            IList<ILogEventRequest> logEvents = new List<ILogEventRequest>();

            foreach (var logEvent in serilogLogEvents)
            {
                logEvents.Add(CreateLogEvent(logEvent));
            }

            await _logEventWriter.BatchCreateAsync(logEvents);
        }

        #endregion

        #region Private Methods

        private LogEvent CreateLogEvent(SerilogLogEvent serilogLogEvent)
        {
            string machineName = FindValue(serilogLogEvent, "MachineName");
            int processId = Convert.ToInt32(FindValue(serilogLogEvent, "ProcessId"));

            var logEvent = new LogEvent
            {
                ApplicationName = _applicationName,
                MachineName = machineName,
                ProcessId =  processId,
                UserId = null,
                MessageTemplate = serilogLogEvent.MessageTemplate.Text,
                Message = serilogLogEvent.RenderMessage(),
                Exception = serilogLogEvent.Exception?.ToString(),
                Level = _logLevelMap[serilogLogEvent.Level],
                Timestamp = DateTime.UtcNow
            };

            return logEvent;
        }

        private string FindValue(SerilogLogEvent serilogLogEvent, string propertyName)
        {
            string value = null;
            LogEventPropertyValue propertyValue;

            if (serilogLogEvent.Properties.TryGetValue(propertyName, out propertyValue))
            {
                value = propertyValue.ToString();
            }

            return value;
        }

        #endregion
    }
}
