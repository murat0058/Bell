using System.Collections.Generic;
using Bell.Common.Models.Configuration;

namespace Bell.Common.Configuration
{
    public interface IApplicationSettings
    {
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
    }

    public class ApplicationSettings : IApplicationSettings
    {
        #region Constructors

        public ApplicationSettings(ApplicationConfiguration configuration)
        {
            ApplicationName = configuration.ApplicationName;
            ApplicationToken = configuration.ApplicationToken;
            ConnectionStrings = configuration.ConnectionStrings;
            UniversalApplicationId = configuration.UniversalApplicationId;
        }

        #endregion

        #region Public Properties

        public string ApplicationName { get; }

        public string ApplicationToken { get; }

        public IDictionary<string, string> ConnectionStrings { get; }

        public string UniversalApplicationId { get; }

        #endregion
    }
}
