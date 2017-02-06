using DryIoc;
using Bell.Common.Models;
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
        /// <remarks>Used to register the module's types</remarks>
        /// </summary>
        public static void Register(IRegistrator builder)
        {
            builder.Register<ILog, Log>();
            builder.Register<ILanguageTranslator, LanguageTranslator>();
            builder.Register<ILogEventRequest, LogEvent>();
        }
    }
}
