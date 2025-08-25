using System.Text;

namespace travel_agency_wform.Services.Security
{
    public static class DataEncryptionServiceTests
    {
        public static void RunTests()
        {
            var encryptionService = DataEncryptionService.Instance;
            
            // Test 1: Basic encryption/decryption
            var originalText = "AB123456";
            var encrypted = encryptionService.Encrypt(originalText);
            var decrypted = encryptionService.Decrypt(encrypted);
            
            Console.WriteLine($"Test 1 - Basic Encryption:");
            Console.WriteLine($"Original: {originalText}");
            Console.WriteLine($"Encrypted: {encrypted}");
            Console.WriteLine($"Decrypted: {decrypted}");
            Console.WriteLine($"Success: {originalText == decrypted}");
            Console.WriteLine();
            
            // Test 2: Empty string handling
            var emptyOriginal = "";
            var emptyEncrypted = encryptionService.Encrypt(emptyOriginal);
            var emptyDecrypted = encryptionService.Decrypt(emptyEncrypted);
            
            Console.WriteLine($"Test 2 - Empty String:");
            Console.WriteLine($"Original: '{emptyOriginal}'");
            Console.WriteLine($"Encrypted: '{emptyEncrypted}'");
            Console.WriteLine($"Decrypted: '{emptyDecrypted}'");
            Console.WriteLine($"Success: {emptyOriginal == emptyDecrypted}");
            Console.WriteLine();
            
            // Test 3: Phone number encryption
            var phoneNumber = "+1-555-0123";
            var phoneEncrypted = encryptionService.Encrypt(phoneNumber);
            var phoneDecrypted = encryptionService.Decrypt(phoneEncrypted);
            
            Console.WriteLine($"Test 3 - Phone Number:");
            Console.WriteLine($"Original: {phoneNumber}");
            Console.WriteLine($"Encrypted: {phoneEncrypted}");
            Console.WriteLine($"Decrypted: {phoneDecrypted}");
            Console.WriteLine($"Success: {phoneNumber == phoneDecrypted}");
            Console.WriteLine();
            
            // Test 4: IsEncrypted detection
            var isEncrypted1 = encryptionService.IsEncrypted(encrypted);
            var isEncrypted2 = encryptionService.IsEncrypted(originalText);
            
            Console.WriteLine($"Test 4 - Encryption Detection:");
            Console.WriteLine($"Encrypted text is encrypted: {isEncrypted1}");
            Console.WriteLine($"Plain text is encrypted: {isEncrypted2}");
            Console.WriteLine($"Success: {isEncrypted1 && !isEncrypted2}");
            Console.WriteLine();
            
            // Test 5: Different inputs produce different outputs
            var text1 = "AB123456";
            var text2 = "CD789012";
            var encrypted1 = encryptionService.Encrypt(text1);
            var encrypted2 = encryptionService.Encrypt(text2);
            
            Console.WriteLine($"Test 5 - Uniqueness:");
            Console.WriteLine($"Text1 encrypted: {encrypted1}");
            Console.WriteLine($"Text2 encrypted: {encrypted2}");
            Console.WriteLine($"Different outputs: {encrypted1 != encrypted2}");
            Console.WriteLine($"Success: {encrypted1 != encrypted2}");
        }
    }
}
