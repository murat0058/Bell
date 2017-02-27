using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bell.Common.Models.Security
{
    /// <summary>
    /// Represents a verify access token request
    /// </summary>
    public class VerifyAccessTokenRequest
    {
        /// <summary>
        /// The access token
        /// </summary>
        public string AccessToken { get; set; }
    }
}
