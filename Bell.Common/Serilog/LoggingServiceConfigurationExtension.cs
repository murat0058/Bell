using System;
using Bell.Common.Services;
using Serilog;
using Serilog.Configuration;
using Serilog.Core;
using Serilog.Events;

namespace Bell.Common.Serilog
{
    /// <summary>
    /// Extension methods for adding a logging service to Serilog
    /// </summary>
    public static class LoggingServiceConfigurationExtension
    {
        #region Public Methods

        /// <summary>
        /// Extension for adding a logging service to Serilog
        /// </summary>
        /// <param name="sinkConfiguration">The sink configuration</param>
        /// <param name="logEventWriter">The log event writer</param>
        /// <param name="applicationName">The application's name</param>
        /// <param name="period">The rate of sending logs to the logging service</param>
        /// <param name="batchPostingLimit">The maximum number of logs sent in each batch</param>
        /// <returns></returns>
        public static LoggerConfiguration LoggingService(this LoggerSinkConfiguration sinkConfiguration, ILogEventWriter logEventWriter, string applicationName, TimeSpan? period = null, int batchPostingLimit = 100)
        {
            TimeSpan batchingPeriod = period ?? TimeSpan.FromSeconds(5);

            return ConfigureLoggingService(sinkConfiguration.Sink, logEventWriter, applicationName, batchingPeriod, batchPostingLimit);
        }

        #endregion

        #region Private Methods

        private static LoggerConfiguration ConfigureLoggingService(
            this Func<ILogEventSink, LogEventLevel, LoggingLevelSwitch, LoggerConfiguration> addSink,
            ILogEventWriter logEventWriter,
            string applicationName,
            TimeSpan period,
            int batchPostingPeriod)
        {
            var sink = new LoggingServiceSink(logEventWriter, applicationName, batchPostingPeriod, period);
            return addSink(sink, LevelAlias.Minimum, null);
        }

        #endregion

    }
}
