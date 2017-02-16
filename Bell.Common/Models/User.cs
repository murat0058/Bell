using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bell.Common.Models
{
    public class User : UserIdentifier
    {
        /// <summary>
        /// Gets or sets the person's first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the person's last name
        /// </summary>
        public string LastName { get; set; }
    }
}
