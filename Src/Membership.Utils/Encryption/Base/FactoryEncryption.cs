using System;

namespace Membership.Utils.Encryption.Base
{
    public static class FactoryEncryption
    {
        public static IEncryption GetInstance(EncryptionType encryptionType)
        {
            switch (encryptionType)
            {
                case EncryptionType.AesEncryiption:
                    return new AesEncryption();
                
                case EncryptionType.TripleDes:
                    return new CryptographyHelper();

                default:
                    throw new ArgumentOutOfRangeException("Not found encryption type in encrypted list!");
            }

        }
    }
}
