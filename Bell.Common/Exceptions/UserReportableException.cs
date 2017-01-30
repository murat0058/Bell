using System;

namespace Bell.Common.Exceptions
{
    /// <summary>
    ///  Represents a user reportable exception
    /// </summary>
    public class UserReportableException: Exception
    {
        #region Public Constructors

        /// <summary>
        /// Instantiates a user reportable exception
        /// </summary>
        /// <param name="errorMessageKey">The language translation key for the error message</param>
        public UserReportableException(string errorMessageKey) : this(new UserReportableMessage(errorMessageKey))
        {
        }

        /// <summary>
        /// Instantiates a user reportable exception
        /// </summary>
        /// <param name="errorMessageKey">The language translation key for the error message</param>
        /// <param name="errorMessageArguments">The argumetns for the generated error message</param>
        public UserReportableException(string errorMessageKey, params object[] errorMessageArguments) : 
            this(new UserReportableMessage(errorMessageKey, errorMessageArguments))
        {
        }

        /// <summary>
        /// Instantiates a user reportable exception
        /// </summary>
        /// <param name="errorMessage">The error message for the exception</param>
        public UserReportableException(UserReportableMessage errorMessage): base()
        {
            ErrorMessage = errorMessage;
        }

        /// <summary>
        /// Instantiates a user reportable exception
        /// </summary>
        /// <param name="errorMessage">The error message for the exception</param>
        /// <param name="exception">The inner exception</param>
        public UserReportableException(Exception exception, UserReportableMessage errorMessage) : base(errorMessage.Key, exception)
        {
            ErrorMessage = errorMessage;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the error code for the error message associated with this 
        /// </summary>
        public UserReportableMessage ErrorMessage { get; private set; }

        #endregion
    }
}
