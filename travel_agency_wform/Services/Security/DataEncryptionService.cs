using System.Security.Cryptography;
using System.Text;

namespace travel_agency_wform.Services.Security
{
    public class DataEncryptionService
    {
        private static readonly Lazy<DataEncryptionService> _instance = 
            new Lazy<DataEncryptionService>(() => new DataEncryptionService());
        
        public static DataEncryptionService Instance => _instance.Value;
        
        private readonly byte[] _key;
        private readonly byte[] _iv;
        
        private DataEncryptionService()
        {
            // Keys for demo purposes, using hardcoded values for AES-256
            var keyString = "YourSecretKey12345678901234567890123456789012"; // 32 bytes for AES-256
            var ivString = "YourSecretIV123456"; // 16 bytes for AES
            
            // Ensure proper key size (32 bytes for AES-256)
            using var sha256 = SHA256.Create();
            _key = sha256.ComputeHash(Encoding.UTF8.GetBytes(keyString));
            
            // Ensure proper IV size (16 bytes)
            using var md5 = MD5.Create();
            _iv = md5.ComputeHash(Encoding.UTF8.GetBytes(ivString));
        }
        
        public string Encrypt(string plainText)
        {
            if (string.IsNullOrEmpty(plainText))
                return plainText;
                
            using var aes = Aes.Create();
            aes.Key = _key;
            aes.IV = _iv;
            
            using var encryptor = aes.CreateEncryptor();
            using var msEncrypt = new MemoryStream();
            using var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
            using var swEncrypt = new StreamWriter(csEncrypt);
            
            swEncrypt.Write(plainText);
            swEncrypt.Flush();
            csEncrypt.FlushFinalBlock();
            
            return Convert.ToBase64String(msEncrypt.ToArray());
        }
        
        public string Decrypt(string cipherText)
        {
            if (string.IsNullOrEmpty(cipherText))
                return cipherText;
                
            try
            {
                using var aes = Aes.Create();
                aes.Key = _key;
                aes.IV = _iv;
                
                using var decryptor = aes.CreateDecryptor();
                using var msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText));
                using var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
                using var srDecrypt = new StreamReader(csDecrypt);
                
                return srDecrypt.ReadToEnd();
            }
            catch
            {
                // If decryption fails, return the original text (might be unencrypted legacy data)
                return cipherText;
            }
        }
        
    }
}
