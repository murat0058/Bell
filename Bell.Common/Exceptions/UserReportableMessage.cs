namespace Bell.Common.Exceptions
{
    /// <summary>
    /// Represents a user reportable message
    /// </summary>
    public class UserReportableMessage
    {
        #region Constructors

        /// <summary>
        /// Instantiates a user reportable message
        /// </summary>
        /// <param name="key">The language translation key used to generate the message</param>
        public UserReportableMessage(string key)
        {
            Key = key;
        }

        /// <summary>
        /// Instantiates a user reportable message
        /// </summary>
        /// <param name="key">The language translation key used to generate the message</param>
        /// <param name="arguments">The arguments used with the translated message</param>
        public UserReportableMessage(string key, params object[] arguments)
        {
            Key = key;
            Arguments = arguments;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the langauge translation key used to generate the message
        /// </summary>
        public string Key { get; private set; }

        /// <summary>
        /// Gets the arguments using with the translated message
        /// </summary>
        public object[] Arguments { get; private set; }

        #endregion
    }
}
