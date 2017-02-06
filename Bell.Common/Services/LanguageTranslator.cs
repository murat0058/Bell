using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bell.Common.Models;

namespace Bell.Common.Services
{
    public interface ILanguageTranslator
    {
        /// <summary>
        /// Translates the key into the languaged specified by the id
        /// </summary>
        /// <param name="languageId">The language id (e.g. "en" or "en-US")</param>
        /// <param name="key">The translation key</param>
        /// <param name="arguments">The arguments associated with the translation string</param>
        /// <returns>The translated string</returns>
        Task<string> TranslateAsync(string languageId, string key, params object[] arguments);
    }

    public class LanguageTranslator : ILanguageTranslator
    {
        #region Private Fields

        private const string _memoryCacheKey = "LANGUAGE_TRANSLATION_REPOSITORY_CACHE";

        private readonly MemoryCacheEntryOptions _cacheOptions;
        private readonly IMemoryCache _memoryCache;

        #endregion

        #region Constructors

        public LanguageTranslator(IMemoryCache memoryCache)
        {
            _cacheOptions = new MemoryCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1) };
            _memoryCache = memoryCache;
        }

        #endregion

        #region Public Methods

        public async Task<string> TranslateAsync(string languageId, string key, params object[] arguments)
        {
            var translationsByKey = await LoadAsync(languageId);

            LanguageTranslation translation;

            if (!translationsByKey.TryGetValue(key, out translation))
            {
                translation = new LanguageTranslation { LanguageId = languageId, Key = key, Value = key };
            }

            return arguments == null ? translation.Value : string.Format(translation.Value, arguments);
        }

        #endregion

        #region Private Methods

        private async Task<IDictionary<string, LanguageTranslation>> LoadAsync(string languageId)
        {
            IDictionary<string, LanguageTranslation> translationsByKey = LoadFromMemory(languageId);

            if (translationsByKey == null)
            {
                translationsByKey = await LoadFromLanguageServiceAsync(languageId);

                if (translationsByKey != null)
                {
                    AddToMemory(languageId, translationsByKey);
                }
            }

            return translationsByKey;
        }

        private async Task<IDictionary<string, LanguageTranslation>> LoadFromLanguageServiceAsync(string languageId)
        {
            // TODO: Finish call to language service
            throw new NotImplementedException();
            //languageId = languageId.ToLower();

            //var baseLanguageMapping = await connection.GetAsync<LanguageMapping>(languageId);
        }

        private void AddToMemory(string languageId, IDictionary<string, LanguageTranslation> translationsByKey)
        {
            IDictionary<string, IDictionary<string, LanguageTranslation>> translationsByLanguageId;

            if (!_memoryCache.TryGetValue(_memoryCacheKey, out translationsByLanguageId))
            {
                translationsByLanguageId = new Dictionary<string, IDictionary<string, LanguageTranslation>>();
            }

            translationsByLanguageId.Add(languageId, translationsByKey);
            _memoryCache.Set(_memoryCacheKey, translationsByLanguageId, new MemoryCacheEntryOptions() { });
        }

        private IDictionary<string, LanguageTranslation> LoadFromMemory(string languageId)
        {
            IDictionary<string, LanguageTranslation> translationsByKey = null;
            IDictionary<string, IDictionary<string, LanguageTranslation>> translationsByLanguageId;

            if (_memoryCache.TryGetValue(_memoryCacheKey, out translationsByLanguageId))
            {
                translationsByLanguageId.TryGetValue(languageId, out translationsByKey);
            }

            return translationsByKey;
        }

        #endregion
    }
}
