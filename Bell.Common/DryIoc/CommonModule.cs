using System;
using Bell.Common.Logging;
using DryIoc;
using Microsoft.Extensions.Configuration;

namespace Bell.Common.DryIoc
{
    /// <summary>
    /// The DryIoc module for this project
    /// </summary>
    public class CommonModule: IModule
    {
        /// <summary> 
        /// Called when the module is loaded
        /// </summary>
        /// <param name="configuration">The application's configuration</param>
        /// <param name="builder">The registration role of the DryIoc container</param>
        /// <remarks>Used to register the module's types</remarks>
        public void Load(IConfiguration configuration, IRegistrator builder)
        {
            builder.Register<ILog, Log>();
        }
    }
}
