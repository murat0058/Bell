using Bell.Common.Configuration;
using Bell.Common.Models.Configuration;
using DryIoc;
using Bell.Common.Models.Logging;
using Bell.Common.Services;

namespace Bell.Common.DryIoc
{
    /// <summary>
    /// The DryIoc module for this project
    /// </summary>
    public static class CommonModule
    {
        /// <summary> 
        /// Registers this module with DryIoc
        /// <param name="builder">The registration role of the DryIoc container</param>
        /// <param name="configuration">Configuration settings for the application</param>
        /// <remarks>Used to register the module's types</remarks>
        /// </summary>
        public static void Register(IRegistrator builder, ApplicationConfiguration configuration)
        {
            builder.Register<IApplicationSettings, ApplicationSettings>(Reuse.Singleton, 
                Made.Of(() => new ApplicationSettings(configuration)));

            builder.Register<ILog, Log>();
            builder.Register<ILogEventRequest, LogEvent>();

            builder.Register<IAuthenticator, Authenticator>();
            builder.Register<ILanguageTranslator, LanguageTranslator>();
            builder.Register<ILogEventWriter, LogEventWriter>();
        }
    }
}
