using System;

namespace Bell.Common.Exceptions
{
    public class InvalidIdException : Exception
    {
        #region Constructors

        public InvalidIdException() : base("The id value should be positive.")
            {
        }

        #endregion
    }
}
