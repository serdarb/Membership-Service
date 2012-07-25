using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Membership.Utils.Encryption.Base;

namespace Membership.Utils.Encryption
{
    public class AesEncryption : AbstractEncryption
    {
        private byte[] _salt = Encoding.ASCII.GetBytes("o6806642kbM7c5");

        private const string _secretKey = "dsa2fr43t34r*";

        public override string Encrypt(string plainText)
        {

            if (string.IsNullOrEmpty(plainText))
                throw new ArgumentNullException("plainText");
          
            string outStr = null;               

            RijndaelManaged aesAlg = null;      

            try
            {
                var key = new Rfc2898DeriveBytes(_secretKey, _salt);

                // Create a RijndaelManaged object
                aesAlg = new RijndaelManaged();

                aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);

                // Create a decrytor to perform the stream transform.
                var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (var msEncrypt = new MemoryStream())
                {
                    msEncrypt.Write(BitConverter.GetBytes(aesAlg.IV.Length), 0, sizeof(int));
                    
                    msEncrypt.Write(aesAlg.IV, 0, aesAlg.IV.Length);
                    
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                    }

                    outStr = Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
            finally
            {
                if (aesAlg != null)
                    aesAlg.Clear();
            }

            return outStr;
        }
         
        public override string Decrypt(string cipherText)
        {
            if (string.IsNullOrEmpty(cipherText))
                throw new ArgumentNullException("cipherText");
          
          
            RijndaelManaged aesAlg = null;

            string plaintext = null;

            try
            {
                // generate the key from the shared secret and the salt
                var key = new Rfc2898DeriveBytes(_secretKey, _salt);

                // Create the streams used for decryption.                
                var bytes = Convert.FromBase64String(cipherText);
                
                using (var msDecrypt = new MemoryStream(bytes))
                {
                    // Create a RijndaelManaged object
                    // with the specified key and IV.
                    aesAlg = new RijndaelManaged();

                    aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);

                    // Get the initialization vector from the encrypted stream
                    aesAlg.IV = ReadByteArray(msDecrypt);

                    // Create a decrytor to perform the stream transform.
                    var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                    
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (var srDecrypt = new StreamReader(csDecrypt))

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                    }
                }
            }
            finally
            {
                // Clear the RijndaelManaged object.
                if (aesAlg != null)
                    aesAlg.Clear();
            }

            return plaintext;
        }

        private byte[] ReadByteArray(Stream s)
        {
            var rawLength = new byte[sizeof(int)];
            
            if (s.Read(rawLength, 0, rawLength.Length) != rawLength.Length)
            {
                throw new SystemException("Stream did not contain properly formatted byte array");
            }

            var buffer = new byte[BitConverter.ToInt32(rawLength, 0)];
            
            if (s.Read(buffer, 0, buffer.Length) != buffer.Length)
            {
                throw new SystemException("Did not read byte array properly");
            }

            return buffer;
        }

    }
}
