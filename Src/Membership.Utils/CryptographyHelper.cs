using System;
using System.Collections;
using System.Security.Cryptography;
using System.Text;

namespace Membership.Utils
{
    public class CryptographyHelper
    {
        private const string Key = ".membership-service#3des%key,";

        /// <summary>
        /// Hashes String With SHA256 Algorithm
        /// </summary>
        /// <param name="textToHash">Text to Hash</param>
        /// <returns>The Hash</returns>
        public string SHA256Hasher(string textToHash)
        {
            var enc = Encoding.Unicode.GetEncoder();

            var unicodeText = new byte[textToHash.Length * 2];
            enc.GetBytes(textToHash.ToCharArray(), 0, textToHash.Length, unicodeText, 0, true);

            var sha256 = new SHA256CryptoServiceProvider();
            var result = sha256.ComputeHash(unicodeText);

            var sb = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                sb.Append(result[i].ToString("X2"));
            }

            return sb.ToString();
        }
       
        /// <summary>
        /// Encripts given text with TripleDES
        /// </summary>
        /// <param name="textToEncrypt">Text to Encypt</param>
        ///  <param name="key">Public Key</param>
        /// <returns>Encrypted Text</returns>
        public string TripleDESEncrypt(string textToEncrypt)
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
        public string TripleDESDecrypt(string textToDecrypt)
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

        /// <summary>
        /// Xors the 2 component.
        /// </summary>
        /// <param name="compA">Component.</param>
        /// <param name="compB">Component.</param>
        /// <returns>Xor result as string</returns>
        public string XOR(string compA, string compB = null)
        {
            if (compB == null)
            {
                compB = ReverseString(compA);
            }

            var barA = new BitArray(HexToByte(compA));
            var barB = new BitArray(HexToByte(compB));
            var barC = new BitArray(compA.Length);
            barC = barB.Xor(barA);
            var byteC = new byte[barC.Length / 8];
            barC.CopyTo(byteC, 0);

            return ByteToHex(byteC);
        }

        public string ReverseString(string text)
        {
            char[] arr = text.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        private string ByteToHex(byte[] byteData)
        {
            var sb = new StringBuilder();
            foreach (byte b in byteData)
            {
                sb.AppendFormat("{0:X2}", b);
            }
            return sb.ToString();
        }

        private byte[] HexToByte(string hex)
        {
            var arrayByte = new byte[hex.Length / 2];
            for (int i = 0; i < hex.Length; i += 2)
            {
                arrayByte[i / 2] = byte.Parse(hex.Substring(i, 2), System.Globalization.NumberStyles.HexNumber);
            }
            return arrayByte;
        }
    }
}
