using System;

namespace Bell.Common.Exceptions
{
    public class BellCommonException : Exception
    {
        #region Constructors

        public BellCommonException(string message) : base(message)
        {
        }

        public BellCommonException(string message, Exception innerException) : base(message, innerException)
        {
        }

        #endregion
    }
}
