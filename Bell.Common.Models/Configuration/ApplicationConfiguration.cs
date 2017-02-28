using System.Collections.Generic;

namespace Bell.Common.Models.Configuration
{
    /// <summary>
    /// Represents the application's configuration
    /// </summary>
    public class ApplicationConfiguration
    {
        /// <summary>
        /// The name of this application
        /// </summary>
        public string ApplicationName { get; set; }

        /// <summary>
        /// The token used to identify this application
        /// </summary>
        public string ApplicationToken { get; set; }

        /// <summary>
        /// The application's connection strings
        /// </summary>
        public IDictionary<string, string> ConnectionStrings { get; set; }

        /// <summary>
        /// The universal application identifier
        /// </summary>
        public string UniversalApplicationId { get; set; }
    }
}
