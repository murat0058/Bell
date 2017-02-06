﻿namespace Bell.Common.Models
{
    /// <summary>
    /// Represents a language translation
    /// </summary>
    public class LanguageTranslation
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the language id (e.g. "en" or "en-US")
        /// </summary>
        public string LanguageId { get; set; }

        /// <summary>
        /// Gets or sets the language translation key
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets the language value associated with the key
        /// </summary>
        public string Value { get; set; }

        #endregion
    }
}