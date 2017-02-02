using System;

namespace Bell.Common.Exceptions
{
    public class RepositoryException : Exception
    {
        #region Constructors

        public RepositoryException(string message) : base(message)
        {
        }

        public RepositoryException(string message, Exception innerException) : base(message, innerException)
        {
        }

        #endregion
    }
}
