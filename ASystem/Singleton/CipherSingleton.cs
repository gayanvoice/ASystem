using Microsoft.AspNetCore.DataProtection;

namespace ASystem.Singleton
{
    public sealed class CipherSingleton
    {
        private static CipherSingleton instance = null;
        private static readonly object padlock = new object();
        private const string AppName = "ASystem";
        private const string Key = "Gayan100638182K%Y";
        CipherSingleton()
        {
        }
        public static CipherSingleton Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new CipherSingleton();
                    }
                    return instance;
                }
            }
        }
        public string Encrypt(string input)
        {
            var dataProtectionProvider = DataProtectionProvider.Create(AppName);
            var protector = dataProtectionProvider.CreateProtector(Key);
            return protector.Protect(input);
        }
        public string Decrypt(string cipherText)
        {
            var dataProtectionProvider = DataProtectionProvider.Create(AppName);
            var protector = dataProtectionProvider.CreateProtector(Key);
            return protector.Unprotect(cipherText);
        }
    }
}