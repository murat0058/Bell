using System;
using System.Security.Cryptography;

namespace Bell.Cryptography
{
    public static class CryptographyEngine
    {
        #region Private Fields

        private const int _workFactor = 12;
        private const int _apiKeySize = 64;
        private const string _pepper = "N)O@eTuVBuFzpFqGGbM27KYp1x^w";

        #endregion

        #region Public Methods

        /// <summary>
        /// Generates a hash, given the input and salt
        /// </summary>
        /// <param name="input">The input to hash</param>
        /// <param name="salt">The salt value to use</param>
        /// <returns>The hashed input</returns>
        public static string GenerateHash(string input, string salt)
        {
            return BCrypt.Net.BCrypt.HashPassword(input, salt + _pepper);
        }

        /// <summary>
        /// Generates a random salt value
        /// </summary>
        /// <returns>The salt value</returns>
        public static string GenerateSalt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt(_workFactor);
        }

        public static string GenerateApiToken()
        {
            var key = new byte[_apiKeySize];

            using (var generator = RandomNumberGenerator.Create())
            {
                generator.GetBytes(key);
            }

            return Convert.ToBase64String(key);
        }

        #endregion
    }
}
