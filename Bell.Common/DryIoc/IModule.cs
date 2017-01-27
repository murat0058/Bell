﻿using DryIoc;
using Microsoft.Extensions.Configuration;

namespace Bell.Common.DryIoc
{
    public interface IModule
    {
        /// <summary> 
        /// Called when the module is loaded
        /// </summary>
        /// <param name="configuration">The application's configuration information</param>
        /// <param name="builder">The registration role of the DryIoc container</param>
        /// <remarks>Used to register the module's types</remarks>
        void Load(IConfiguration configuration, IRegistrator builder);
    }
}
