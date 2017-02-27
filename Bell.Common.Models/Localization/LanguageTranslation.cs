namespace Bell.Common.Models.Localization
{
    /// <summary>
    /// Represents a language translation
    /// </summary>
    public class LanguageTranslation
    {
        #region Public Properties

        /// <summary>
        /// The language id (e.g. "en" or "en-US")
        /// </summary>
        public string LanguageId { get; set; }

        /// <summary>
        /// The language translation key
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// The language value associated with the key
        /// </summary>
        public string Value { get; set; }

        #endregion
    }
}