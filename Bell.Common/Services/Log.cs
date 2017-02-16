using Microsoft.Extensions.Logging;
using System;
using Bell.Common.Serilog;
using Serilog;
using SerilogLog = Serilog.Log;

namespace Bell.Common.Services
{
    /// <summary>
    /// The logging system
    /// </summary>
    public interface ILog
    {
        void Debug(string message);

        void Debug(string messageTemplate, params object[] propertyValues);

        void Debug<T>(string messageTemplate, T propertyValue);

        void Debug<T0, T1>(string messageTemplate, T0 propertyValue0, T1 propertyValue1);

        void Information(string message);

        void Information(string messageTemplate, params object[] propertyValues);

        void Information<T>(string messageTemplate, T propertyValue);

        void Information<T0, T1>(string messageTemplate, T0 propertyValue0, T1 propertyValue1);

        void Warning(string message);

        void Warning(string messageTemplate, params object[] propertyValues);

        void Warning<T>(string messageTemplate, T propertyValue);

        void Warning<T0, T1>(string messageTemplate, T0 propertyValue0, T1 propertyValue1);

        void Error(Exception exception, string message);

        void Error(Exception exception, string messageTemplate, params object[] propertyValues);

        void Error<T>(Exception exception, string messageTemplate, T propertyValue);

        void Error<T0, T1>(Exception exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1);
    }

    /// <summary>
    /// The logging system
    /// </summary>
    public class Log : ILog
    {
        #region Constructors 

        /// <summary>
        /// Configures the Logger
        /// </summary>
        /// <param name="loggerFactory">The logger factory for the application</param>
        /// <param name="logEventWriter">The log event writer</param>
        /// <param name="applicationName">The application's name</param>
        public static void Configure(ILoggerFactory loggerFactory, ILogEventWriter logEventWriter, string applicationName)
        {
            SerilogLog.Logger =
                new LoggerConfiguration()
                    .MinimumLevel.Warning()
                    .WriteTo.LoggingService(logEventWriter, applicationName)
                    .Enrich.WithMachineName()
                    .Enrich.WithProcessId()
                    .CreateLogger();

            loggerFactory.AddSerilog();
        }

        #endregion

        #region Public Methods

        public void Debug(string message)
        {
            SerilogLog.Debug(message);
        }

        public void Debug(string messageTemplate, params object[] propertyValues)
        {
            SerilogLog.Debug(messageTemplate, propertyValues);
        }

        public void Debug<T>(string messageTemplate, T propertyValue)
        {
            SerilogLog.Debug<T>(messageTemplate, propertyValue);
        }

        public void Debug<T0, T1>(string messageTemplate, T0 propertyValue0, T1 propertyValue1)
        {
            SerilogLog.Debug(messageTemplate, propertyValue0, propertyValue1);
        }

        public void Information(string message)
        {
            SerilogLog.Information(message);
        }

        public void Information(string messageTemplate, params object[] propertyValues)
        {
            SerilogLog.Information(messageTemplate, propertyValues);
        }

        public void Information<T>(string messageTemplate, T propertyValue)
        {
            SerilogLog.Information(messageTemplate, propertyValue);
        }

        public void Information<T0, T1>(string messageTemplate, T0 propertyValue0, T1 propertyValue1)
        {
            SerilogLog.Information(messageTemplate, propertyValue0, propertyValue1);
        }

        public void Warning(string message)
        {
            SerilogLog.Warning(message);
        }

        public void Warning(string messageTemplate, params object[] propertyValues)
        {
            SerilogLog.Warning(messageTemplate, propertyValues);
        }

        public void Warning<T>(string messageTemplate, T propertyValue)
        {
            SerilogLog.Warning(messageTemplate, propertyValue);
        }

        public void Warning<T0, T1>(string messageTemplate, T0 propertyValue0, T1 propertyValue1)
        {
            SerilogLog.Warning(messageTemplate, propertyValue0, propertyValue1);
        }

        public void Error(Exception exception, string message)
        {
            SerilogLog.Error(exception, message);
        }

        public void Error(Exception exception, string messageTemplate, params object[] propertyValues)
        {
            SerilogLog.Error(exception, messageTemplate, propertyValues);
        }

        public void Error<T>(Exception exception, string messageTemplate, T propertyValue)
        {
            SerilogLog.Error(exception, messageTemplate, propertyValue);
        }

        public void Error<T0, T1>(Exception exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1)
        {
            SerilogLog.Error(exception, messageTemplate, propertyValue0, propertyValue1);
        }
        
        #endregion
    }
}
