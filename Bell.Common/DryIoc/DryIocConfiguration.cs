using DryIoc;

namespace Bell.Common.DryIoc
{
    /// <summary>
    /// The DryIoc configuration information
    /// </summary>
    public static class DryIocConfiguration
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the DryIOC container for this application
        /// </summary>
        public static IContainer Container { get; set; }

        #endregion
    }
}
