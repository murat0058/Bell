namespace Bell.Common.Globalization
{
    /// <summary>
    /// Represents a language mapping - maps the language id to its base language
    /// </summary>
    public class LanguageMapping
    {
        #region Public Properties

        /// <summary>
        /// The language id (e.g. "en-US" or "en-UK")
        /// </summary>
        public string LanguageId { get; set; }

        /// <summary>
        /// The base language for the specific language (e.g. "en" for "en-US" or "en-UK")
        /// </summary>
        public string BaseLanguageId { get; set; }

        #endregion
    }
}
