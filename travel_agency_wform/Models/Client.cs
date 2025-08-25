using System.ComponentModel.DataAnnotations;
using travel_agency_wform.Services.Security;

namespace travel_agency_wform.Models
{
    public class Client
    {
        private readonly DataEncryptionService _encryptionService = DataEncryptionService.Instance;
        
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;
        
        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;
        
        [Required]
        [StringLength(20)]
        public string PassportNumber 
        { 
            get => _encryptionService.Decrypt(_encryptedPassportNumber);
            set => _encryptedPassportNumber = _encryptionService.Encrypt(value);
        }
        
        private string _encryptedPassportNumber = string.Empty;
        
        [Required]
        public DateTime DateOfBirth { get; set; }
        
        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;
        
        [Required]
        [Phone]
        [StringLength(20)]
        public string PhoneNumber 
        { 
            get => _encryptionService.Decrypt(_encryptedPhoneNumber);
            set => _encryptedPhoneNumber = _encryptionService.Encrypt(value);
        }
        
        private string _encryptedPhoneNumber = string.Empty;
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
        
        public string FullName => $"{FirstName} {LastName}";
        
        // For database operations - get encrypted values
        public string GetEncryptedPassportNumber() => _encryptedPassportNumber;
        public string GetEncryptedPhoneNumber() => _encryptedPhoneNumber;
        
        // For database operations - set encrypted values
        public void SetEncryptedPassportNumber(string encryptedValue) => _encryptedPassportNumber = encryptedValue;
        public void SetEncryptedPhoneNumber(string encryptedValue) => _encryptedPhoneNumber = encryptedValue;
    }
}
