namespace Bell.Common.Models.Security
{
    /// <summary>
    /// The authorization type
    /// </summary>
    public enum AuthorizationType
    {
        /// <summary>
        /// No authorization
        /// </summary>
       None = 0,

       /// <summary>
       /// Any type of authorization
       /// </summary>
       Any,

       /// <summary>
       /// Application-based authorization
       /// </summary>
       Application,

       /// <summary>
       /// User-based authorization
       /// </summary>
       User
    }
}
