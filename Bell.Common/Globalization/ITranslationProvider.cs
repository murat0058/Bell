using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bell.Common.Globalization
{
    /// <summary>
    /// Provides translations for a particular language id
    /// </summary>
    public interface ITranslationProvider
    {
        /// <summary>
        /// Loads the translations from the provider
        /// </summary>
        /// <param name="languageId">The language id for the translations to load</param>
        /// <returns>A dictionary of translations, organized by the translation key</returns>
        Task<IDictionary<string, Translation>> LoadAsync(string languageId);
    }
}
