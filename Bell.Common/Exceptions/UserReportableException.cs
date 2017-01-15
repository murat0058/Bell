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
        /// <param name="errorCode">The error code for the exception</param>
        public UserReportableException(string errorCode): base()
        {
            ErrorCode = errorCode;
        }

        /// <summary>
        /// Instantiates a user reportable exception
        /// </summary>
        /// <param name="errorCode">The error code for the exception</param>
        /// <param name="innerException">The inner exception</param>
        public UserReportableException(string errorCode, Exception innerException): base(errorCode, innerException)
        {
            ErrorCode = errorCode;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the error code of the exception
        /// </summary>
        public string ErrorCode { get; private set; }

        #endregion
    }
}
