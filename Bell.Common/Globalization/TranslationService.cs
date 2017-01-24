using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bell.Common.Globalization
{
    /// <summary>
    /// Represents a translation service
    /// </summary>
    public interface ITranslationService
    {
        /// <summary>
        /// Loads the language translations for the given language
        /// </summary>
        /// <param name="languageId">The language id (e.g. "en" or "en-US")</param>
        /// <returns>The language translations, keyed by their keys</returns>
        Task<IDictionary<string, Translation>> LoadAsync(string languageId);

        /// <summary>
        /// Translates the key into the languaged specified by the id
        /// </summary>
        /// <param name="languageId">The language id (e.g. "en" or "en-US")</param>
        /// <param name="key">The translation key</param>
        /// <param name="arguments">The arguments associated with the translation string</param>
        /// <returns>The translated string</returns>
        Task<string> TranslateAsync(string languageId, string key, params object[] arguments);
    }

    public class TranslationService : ITranslationService
    {
        #region Private Fields

        private const string _memoryCacheKey = "TRANSLATION_SERVICE_CACHE";

        private readonly MemoryCacheEntryOptions _cacheOptions;
        private readonly IMemoryCache _memoryCache;
        private readonly ITranslationProvider _translationProvider;

        #endregion

        #region Constructors

        public TranslationService(IMemoryCache memoryCache, ITranslationProvider translationProvider)
        {
            _cacheOptions = new MemoryCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1) };
           _memoryCache = memoryCache;
            _translationProvider = translationProvider;
        }

        #endregion

        #region Public Methods

        public async Task<IDictionary<string, Translation>> LoadAsync(string languageId)
        {
            IDictionary<string, Translation> translationsByKey = LoadFromMemory(languageId);

            if (translationsByKey == null)
            {
                translationsByKey = await _translationProvider.LoadAsync(languageId);

                if (translationsByKey != null)
                {
                    AddToMemory(languageId, translationsByKey);
                }
            }

            return translationsByKey;
        }

        public async Task<string> TranslateAsync(string languageId, string key, params object[] arguments)
        {
            var translationsByKey = await LoadAsync(languageId);

            Translation translation;

            if (!translationsByKey.TryGetValue(key, out translation))
            {
                translation = new Translation { LanguageId = languageId, Key = key, Value = key };
            }

            return string.Format(translation.Value, arguments);
        }

        #endregion

        #region Private Methods

        private void AddToMemory(string languageId, IDictionary<string, Translation> translationsByKey)
        {
            IDictionary<string, IDictionary<string, Translation>> translationsByLanguageId;

            if (!_memoryCache.TryGetValue(_memoryCacheKey, out translationsByLanguageId))
            {
                translationsByLanguageId = new Dictionary<string, IDictionary<string, Translation>>();
            }

            translationsByLanguageId.Add(languageId, translationsByKey);
           _memoryCache.Set(_memoryCacheKey, translationsByLanguageId, new MemoryCacheEntryOptions() {  });
        }

        private IDictionary<string, Translation> LoadFromMemory(string languageId)
        {
            IDictionary<string, Translation> translationsByKey = null;
            IDictionary<string, IDictionary<string, Translation>> translationsByLanguageId;

            if (_memoryCache.TryGetValue(_memoryCacheKey, out translationsByLanguageId))
            {
                translationsByLanguageId.TryGetValue(languageId, out translationsByKey);
            }

            return translationsByKey;
        }

        #endregion
    }
}
