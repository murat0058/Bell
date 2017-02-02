using System;

namespace Bell.Common.Exceptions
{
    public class CollectionEmptyException : Exception
    {
        #region Constructors

        public CollectionEmptyException() : base("Collection is empty.")
        {
        }

        #endregion
    }
}
