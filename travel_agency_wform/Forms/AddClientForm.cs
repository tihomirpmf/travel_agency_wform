using travel_agency_wform.Models;
using travel_agency_wform.Services;

namespace travel_agency_wform.Forms
{
    // Service Layer Integration: Form that uses TravelAgencyService for client operations
    // Purpose: Demonstrates UI integration with service layer and data validation
    public partial class AddClientForm : Form
    {
        private readonly ITravelAgencyService _agencyService;
        
        public AddClientForm(ITravelAgencyService agencyService)
        {
            InitializeComponent();
            _agencyService = agencyService;
            
            // Set up date picker
            dateTimePickerDateOfBirth.MaxDate = DateTime.Today;
            dateTimePickerDateOfBirth.Value = DateTime.Today.AddYears(-25);
        }
        
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                var client = new Client
                {
                    FirstName = textBoxFirstName.Text.Trim(),
                    LastName = textBoxLastName.Text.Trim(),
                    PassportNumber = textBoxPassportNumber.Text.Trim(),
                    DateOfBirth = dateTimePickerDateOfBirth.Value.Date,
                    Email = textBoxEmail.Text.Trim(),
                    PhoneNumber = textBoxPhoneNumber.Text.Trim()
                };
                
                try
                {
                    _ = Task.Run(async () =>
                    {
                        var success = await _agencyService.AddClientAsync(client);
                        
                        if (InvokeRequired)
                        {
                            Invoke(new Action(() =>
                            {
                                if (success > 0)
                                {
                                    MessageBox.Show("Client added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    DialogResult = DialogResult.OK;
                                    Close();
                                }
                                else
                                {
                                    MessageBox.Show("Failed to add client.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }));
                        }
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding client: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(textBoxFirstName.Text))
            {
                MessageBox.Show("First name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxFirstName.Focus();
                return false;
            }
            
            if (string.IsNullOrWhiteSpace(textBoxLastName.Text))
            {
                MessageBox.Show("Last name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxLastName.Focus();
                return false;
            }
            
            if (string.IsNullOrWhiteSpace(textBoxPassportNumber.Text))
            {
                MessageBox.Show("Passport number is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxPassportNumber.Focus();
                return false;
            }
            
            if (string.IsNullOrWhiteSpace(textBoxEmail.Text))
            {
                MessageBox.Show("Email is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxEmail.Focus();
                return false;
            }
            
            if (!IsValidEmail(textBoxEmail.Text))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxEmail.Focus();
                return false;
            }
            
            if (string.IsNullOrWhiteSpace(textBoxPhoneNumber.Text))
            {
                MessageBox.Show("Phone number is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxPhoneNumber.Focus();
                return false;
            }
            
            return true;
        }
        
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
