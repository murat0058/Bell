using Bell.Common.Globalization;
using Bell.Database.Connections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Bell.Dapper.Extensions;
using Bell.Dapper.Predicates;

namespace Bell.Database.Globalization
{
    public class TranslationProvider : ITranslationProvider
    {
        #region Private Fields

        private IBellConnection _bellConnection;

        #endregion

        #region Constructors

        public TranslationProvider(IBellConnection bellConnection)
        {
            _bellConnection = bellConnection;
        }

        #endregion

        #region Public Methods

        public async Task<IDictionary<string, Translation>> LoadAsync(string languageId)
        {
            var translationsByKey = await _bellConnection.RunCommandAsync(c => LoadFromDatabaseAsync(c, languageId));
            return translationsByKey;
        }

        #endregion

        #region Private Methods

        private async Task<IDictionary<string, Translation>> LoadFromDatabaseAsync(IDbConnection connection, string languageId)
        {
            languageId = languageId.ToLower();

            var baseLanguageMapping = await connection.GetAsync<LanguageMapping>(languageId);
             
            if (baseLanguageMapping == null)
            {
                throw new DataException(TranslationKeyResources.ERROR_LANGUAGE_ID_NOT_SUPPORTED, languageId);
            }

            // Get the base language translations
            IFieldPredicate predicate = Predicates.Field<Translation>(lt => lt.LanguageId, Operator.Equals, baseLanguageMapping.BaseLanguageId);
            var baseLanguageTranslations = await connection.GetListAsync<Translation>(predicate);

            // Get the specific language translations
            predicate = Predicates.Field<Translation>(lt => lt.LanguageId, Operator.Equals, languageId);
            var languageTranslationsByKey = (await connection.GetListAsync<Translation>(predicate)).ToDictionary(lt => lt.Key);

            return CombineTranslations(baseLanguageTranslations, languageTranslationsByKey).ToDictionary(lt => lt.Key);
        }

        private IEnumerable<Translation> CombineTranslations(IEnumerable<Translation> baseTranslations,
            IDictionary<string, Translation> languageTranslationsByKey)
        {
            var combinedTranslations = new List<Translation>();

            foreach (var translation in baseTranslations)
            {
                Translation translationOverride;

                // If a translation exists for the specific language, override the base language translation value
                if (languageTranslationsByKey.TryGetValue(translation.Key, out translationOverride))
                {
                    translation.Value = translationOverride.Value;
                    languageTranslationsByKey.Remove(translation.Key);
                }

                combinedTranslations.Add(translation);
            }

            // Add any left-over translations in the specific language translations
            combinedTranslations.AddRange(languageTranslationsByKey.Values);

            return combinedTranslations;
        }

        #endregion
    }
}
