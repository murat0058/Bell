using Bell.Common.Logging;
using DryIoc;

namespace Bell.Common.DryIoc
{
    public class CommonModule: IModule
    {
        /// <summary>
        /// Called when the module is loaded
        /// </summary>
        /// <param name="builder">The registration role of the DryIoc container</param>
        /// <remarks>Used to register the module's types</remarks>
        public void Load(IRegistrator builder)
        {
            builder.Register<ILog, Log>();
        }
    }
}
