using System;
using System.Security.Cryptography;
using System.Text;
using Membership.Utils.Encryption.Base;

namespace Membership.Utils.Encryption
{
    public class TripleDESEncyption : AbstractEncryption
    {
        private const string Key = ".membership-service#3des%key,";

        /// <summary>
        /// Encripts given text with TripleDES
        /// </summary>
        /// <param name="textToEncrypt">Text to Encypt</param>
        ///  <param name="key">Public Key</param>
        /// <returns>Encrypted Text</returns>
        public override string Encrypt(string textToEncrypt)
        {
            var keyArray = Encoding.UTF8.GetBytes(Key);
            var toEncryptArray = Encoding.UTF8.GetBytes(textToEncrypt);

            var tdes = new TripleDESCryptoServiceProvider
            {
                Key = keyArray,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };

            var cTransform = tdes.CreateEncryptor();
            var resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }


        /// <summary>
        /// Decripts given text with TripleDES
        /// </summary>
        /// <param name="textToDecrypt">Text to Decrypt</param>
        ///  <param name="key">Public Key</param>
        /// <returns>Decrypted Text</returns>
        public override string Decrypt(string textToDecrypt)
        {
            var keyArray = Encoding.UTF8.GetBytes(Key);
            var toEncryptArray = Convert.FromBase64String(textToDecrypt);

            var tdes = new TripleDESCryptoServiceProvider
            {
                Key = keyArray,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };

            var cTransform = tdes.CreateDecryptor();
            var resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Encoding.UTF8.GetString(resultArray);
        }
    }
}
