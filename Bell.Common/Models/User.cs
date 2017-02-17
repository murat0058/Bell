using Bell.Common.Extensions;

namespace Bell.Common.Models
{
    /// <summary>
    /// Represents the user's identification information
    /// </summary>
    public class UserIdentifier
    {
        #region Public Properties

        /// <summary>
        /// The user's id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// The user's e-mail address
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The user's display name
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The url for the avatar picture representing this user
        /// </summary>
        public string AvatarUrl { get; set; }

        #endregion
    }

    /// <summary>
    /// Represent's the user's information
    /// </summary>
    public class User : UserIdentifier
    {
        #region Constructors

        public User()
        {
            
        }

        public User(UserIdentifier userIdentifier)
        {
            userIdentifier.ThrowIfNull();

            Id = userIdentifier.Id;
            Email = userIdentifier.Email;
            DisplayName = userIdentifier.DisplayName;
            AvatarUrl = userIdentifier.AvatarUrl;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// The user's first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The user's last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The user's preferred language id (e.g. "en" or "en-US")
        /// </summary>
        /// <remarks>Used for setting the language of user interface</remarks>
        public string LanguageId { get; set; }

        /// <summary>
        /// The user's preferred locale id (e.g. "en-US" or "en-GB")
        /// </summary>
        /// <remarks>Used for setting date formats, currency formats, etc.</remarks>
        public string LocaleId { get; set; }

        #endregion
    }
}
