using System;

namespace Bell.Common.Exceptions
{
    public class ServicesException : Exception
    {
        #region Constructors

        public ServicesException(string message) : base(message)
        {
        }

        public ServicesException(string message, Exception innerException) : base(message, innerException)
        {
        }

        #endregion
    }
}
