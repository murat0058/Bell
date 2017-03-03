using System.Collections.Generic;
using Bell.Common.Models.Configuration;

namespace Bell.Common.Configuration
{
    public interface IApplicationSettings
    {
        #region Public Properties

        /// <summary>
        /// The name of this application
        /// </summary>
        string ApplicationName { get; }

        /// <summary>
        /// The token used to identify this application
        /// </summary>
        string ApplicationToken { get; }

        /// <summary>
        /// The application's connection strings
        /// </summary>
        IDictionary<string, string> ConnectionStrings { get; }

        /// <summary>
        /// The universal application identifier
        /// </summary>
        string UniversalApplicationId { get; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Indicates if the current application is in a development environment
        /// </summary>
        bool IsDevelopment();

        /// <summary>
        /// Indicates if the current application is in a staging environment
        /// </summary>
        bool IsStaging();

        /// <summary>
        /// Indicates if the current application is in a production environment
        /// </summary>
        bool IsProduction();

        #endregion
    }

    public class ApplicationSettings : IApplicationSettings
    {
        #region Private Fields

        private readonly string _currentEnvironment;

        #endregion

        #region Constructors

        public ApplicationSettings(ApplicationConfiguration configuration)
        {
            ApplicationName = configuration.ApplicationName;
            ApplicationToken = configuration.ApplicationToken;
            ConnectionStrings = configuration.ConnectionStrings;
            _currentEnvironment = configuration.Environment.ToLower();
            UniversalApplicationId = configuration.UniversalApplicationId;
        }

        #endregion

        #region Public Properties

        public string ApplicationName { get; }

        public string ApplicationToken { get; }

        public IDictionary<string, string> ConnectionStrings { get; }

        public string UniversalApplicationId { get; }

        #endregion

        #region Public Methods

        public bool IsDevelopment()
        {
            return _currentEnvironment == "development";
        }

        public bool IsStaging()
        {
            return _currentEnvironment == "staging";
        }

        public bool IsProduction()
        {
            return _currentEnvironment == "production";
        }

        #endregion
    }
}
