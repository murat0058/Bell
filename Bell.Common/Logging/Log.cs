using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using System;

namespace Bell.Common.Logging
{
    /// <summary>
    /// The logging system
    /// </summary>
    public interface ILog
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
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
        /// <param name="configuration">The application's configuration</param>
        /// <remarks> 
        /*   "Serilog": {
                 "Using": "Serilog.Sinks.RollingFile",
                 "MinimumLevel": "Warning",
                 "WriteTo": [
                    { 
                        "Name": "RollingFile",
                        "Args": {
                            "pathFormat": "\\ProgramData\\Storm\\Logs\\log-{Date}.txt",
                            "outputTemplate": "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} | {MachineName} ({ProcessId}) [{Level}] {Message}{NewLine}{Exception}"
                        }
                    }
                ],
                "Enrich": [ "WithMachineName", "WithProcessId" ],
                "Properties": {
                    "Application": "Storm"
                }
        */
        /// </remarks>
        public static void Configure(IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            Serilog.Log.Logger =
                new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            loggerFactory.AddSerilog();
        }

        #endregion

        #region Public Methods

        public void Debug(string message)
        {
            Serilog.Log.Debug(message);
        }

        public void Debug(string messageTemplate, params object[] propertyValues)
        {
            Serilog.Log.Debug(messageTemplate, propertyValues);
        }

        public void Debug<T>(string messageTemplate, T propertyValue)
        {
            Serilog.Log.Debug<T>(messageTemplate, propertyValue);
        }

        public void Debug<T0, T1>(string messageTemplate, T0 propertyValue0, T1 propertyValue1)
        {
            Serilog.Log.Debug(messageTemplate, propertyValue0, propertyValue1);
        }

        public void Information(string message)
        {
            Serilog.Log.Information(message);
        }

        public void Information(string messageTemplate, params object[] propertyValues)
        {
            Serilog.Log.Information(messageTemplate, propertyValues);
        }

        public void Information<T>(string messageTemplate, T propertyValue)
        {
            Serilog.Log.Information<T>(messageTemplate, propertyValue);
        }

        public void Information<T0, T1>(string messageTemplate, T0 propertyValue0, T1 propertyValue1)
        {
            Serilog.Log.Information(messageTemplate, propertyValue0, propertyValue1);
        }

        public void Warning(string message)
        {
            Serilog.Log.Warning(message);
        }

        public void Warning(string messageTemplate, params object[] propertyValues)
        {
            Serilog.Log.Warning(messageTemplate, propertyValues);
        }

        public void Warning<T>(string messageTemplate, T propertyValue)
        {
            Serilog.Log.Warning<T>(messageTemplate, propertyValue);
        }

        public void Warning<T0, T1>(string messageTemplate, T0 propertyValue0, T1 propertyValue1)
        {
            Serilog.Log.Warning(messageTemplate, propertyValue0, propertyValue1);
        }

        public void Error(Exception exception, string message)
        {
            Serilog.Log.Error(exception, message);
        }

        public void Error(Exception exception, string messageTemplate, params object[] propertyValues)
        {
            Serilog.Log.Error(exception, messageTemplate, propertyValues);
        }

        public void Error<T>(Exception exception, string messageTemplate, T propertyValue)
        {
            Serilog.Log.Error(exception, messageTemplate, propertyValue);
        }

        public void Error<T0, T1>(Exception exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1)
        {
            Serilog.Log.Error(exception, messageTemplate, propertyValue0, propertyValue1);
        }
        
        #endregion
    }
}
