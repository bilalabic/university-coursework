using System;
using System.Security.Cryptography;
using System.Text;

namespace AIChatBotDemo.Helpers
{
    public static class EncryptionHelper
    {
        private static readonly byte[] Entropy = Encoding.UTF8.GetBytes("AIChatBotDemo2026");

        public static string Encrypt(string plainText)
        {
            if (string.IsNullOrEmpty(plainText)) return string.Empty;
            try
            {
                var plainBytes = Encoding.UTF8.GetBytes(plainText);
                var encryptedBytes = ProtectedData.Protect(plainBytes, Entropy, DataProtectionScope.CurrentUser);
                return Convert.ToBase64String(encryptedBytes);
            }
            catch { return string.Empty; }
        }

        public static string Decrypt(string encryptedText)
        {
            if (string.IsNullOrEmpty(encryptedText)) return string.Empty;
            try
            {
                var encryptedBytes = Convert.FromBase64String(encryptedText);
                var plainBytes = ProtectedData.Unprotect(encryptedBytes, Entropy, DataProtectionScope.CurrentUser);
                return Encoding.UTF8.GetString(plainBytes);
            }
            catch { return string.Empty; }
        }
    }
}
