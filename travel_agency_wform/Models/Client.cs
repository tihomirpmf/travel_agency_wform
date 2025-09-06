using System.ComponentModel.DataAnnotations;

namespace travel_agency_wform.Models
{
    public class Client
    {
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
        
        private readonly Services.Security.DataEncryptionService _encryptionService = Services.Security.DataEncryptionService.Instance;
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
        public string PhoneNumber { get; set; } = string.Empty;
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
        
        public string FullName => $"{FirstName} {LastName}";
        public override string ToString()
        {
            return FullName + " - " + PassportNumber;
        }
        
        public string GetEncryptedPassportNumber() => _encryptedPassportNumber;
        public void SetEncryptedPassportNumber(string encryptedValue) => _encryptedPassportNumber = encryptedValue;
    }
}
