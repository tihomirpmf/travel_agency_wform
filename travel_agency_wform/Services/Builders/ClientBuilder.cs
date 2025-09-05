using travel_agency_wform.Models;

namespace travel_agency_wform.Services.Builders
{
    public class ClientBuilder
    {
        private string _firstName = string.Empty;
        private string _lastName = string.Empty;
        private string _passportNumber = string.Empty;
        private DateTime _dateOfBirth = DateTime.Today;
        private string _email = string.Empty;
        private string _phoneNumber = string.Empty;

        public ClientBuilder SetFirstName(string firstName)
        {
            _firstName = firstName ?? string.Empty;
            return this;
        }

        public ClientBuilder SetLastName(string lastName)
        {
            _lastName = lastName ?? string.Empty;
            return this;
        }

        public ClientBuilder SetPassportNumber(string passportNumber)
        {
            _passportNumber = passportNumber ?? string.Empty;
            return this;
        }

        public ClientBuilder SetDateOfBirth(DateTime dateOfBirth)
        {
            _dateOfBirth = dateOfBirth;
            return this;
        }

        public ClientBuilder SetEmail(string email)
        {
            _email = email ?? string.Empty;
            return this;
        }

        public ClientBuilder SetPhoneNumber(string phoneNumber)
        {
            _phoneNumber = phoneNumber ?? string.Empty;
            return this;
        }

        public Client Build()
        {
            return new Client
            {
                FirstName = _firstName,
                LastName = _lastName,
                PassportNumber = _passportNumber,
                DateOfBirth = _dateOfBirth,
                Email = _email,
                PhoneNumber = _phoneNumber
            };
        }
    }
}
