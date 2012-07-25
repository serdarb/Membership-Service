namespace Membership.Utils.Encryption.Base
{
   public  interface IEncryption
   {
       string Encrypt(string plainText);
       string Decrypt(string cipherText);
   }
}
