namespace Membership.Utils.Encryption.Base
{
   public  abstract  class AbstractEncryption : IEncryption
    {
       public abstract string Encrypt(string plainText);

       public abstract string Decrypt(string cipherText);
    }
}
