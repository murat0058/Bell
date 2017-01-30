﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Serilog;
using Serilog.Events;
using System;
using System.Security.Authentication;

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

        /// <summary>
        /// Configures serilog to work with the logging server
        /// </summary>
        /// <param name="loggerFactory">The logger factory</param>
        /// <param name="url">The url of the DocumentDB server</param>
        /// <param name="authorizationKey">The authorization key</param>
        /// <param name="timeToLiveInDays">The time-to-live for log entries (in days)</param>
        public static void ConfigureLogSever(ILoggerFactory loggerFactory)
        {
  //          string connectionString =
  //@"mongodb://bell-log-db:9OnN0I2ZcCo3Fca9DilrsHT5qnihNch7rZ8zwngfcWvFuHjw0nCnQhj6KKaPlLq3xv3Otis1puCCbzQn80qUfw==@bell-log-db.documents.azure.com:10250/?ssl=true&sslverifycertificate=false";
  //          MongoClientSettings settings = MongoClientSettings.FromUrl(
  //            new MongoUrl(connectionString)
  //          );
  //          settings.SslSettings =
  //            new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
  //          var mongoClient = new MongoClient(settings);

  //          Serilog.Log.Logger =
  //              new LoggerConfiguration()
  //              .WriteTo.MongoDB(mongoClient.GetDatabase("log"), restrictedToMinimumLevel: LogEventLevel.Warning)
  //              .CreateLogger();

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
