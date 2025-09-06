using travel_agency_wform.Services;

namespace travel_agency_wform.Forms
{
    public partial class AddClientForm : Form
    {
        private readonly ITravelAgencyFacade _agencyService;
        
        public AddClientForm(ITravelAgencyFacade agencyService)
        {
            InitializeComponent();
            _agencyService = agencyService;
            
            // Set up date picker
            dateTimePickerDateOfBirth.MaxDate = DateTime.Today;
            dateTimePickerDateOfBirth.Value = DateTime.Today.AddYears(-25);
        }
        
        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                var client = _agencyService.CreateClient()
                    .SetFirstName(textBoxFirstName.Text.Trim())
                    .SetLastName(textBoxLastName.Text.Trim())
                    .SetPassportNumber(textBoxPassportNumber.Text.Trim())
                    .SetDateOfBirth(dateTimePickerDateOfBirth.Value)
                    .SetEmail(textBoxEmail.Text.Trim())
                    .SetPhoneNumber(textBoxPhoneNumber.Text.Trim())
                    .Build();
                
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
                MessageBox.Show($"Error creating client: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
