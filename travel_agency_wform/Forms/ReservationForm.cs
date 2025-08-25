using travel_agency_wform.Models;
using travel_agency_wform.Services;
using travel_agency_wform.Services.Commands;

namespace travel_agency_wform.Forms
{
    public partial class ReservationForm : Form
    {
        private readonly TravelAgencyService _agencyService;
        private readonly CommandInvoker _commandInvoker;
        private readonly int _clientId;
        private readonly int _packageId;
        private Client? _client;
        private TravelPackage? _package;
        
        public ReservationForm(TravelAgencyService agencyService, int clientId, int packageId)
        {
            InitializeComponent();
            _agencyService = agencyService;
            _commandInvoker = CommandInvoker.Instance;
            _clientId = clientId;
            _packageId = packageId;
            
            // Set up numeric up down control
            numericUpDownNumberOfTravelers.Minimum = 1;
            numericUpDownNumberOfTravelers.Maximum = 100;
            numericUpDownNumberOfTravelers.Value = 1;
            
            // Load client and package information
            LoadReservationDataAsync();
        }
        
        private async void LoadReservationDataAsync()
        {
            try
            {
                _client = await _agencyService.GetClientByIdAsync(_clientId);
                _package = await _agencyService.GetPackageByIdAsync(_packageId);
                
                if (_client != null && _package != null)
                {
                    labelClientInfo.Text = $"Client: {_client.FullName}";
                    labelPackageInfo.Text = $"Package: {_package.Name} - {_package.Destination} - {_package.Price:C} - {_package.NumberOfDays} days";
                    
                    // Calculate initial total
                    CalculateTotal();
                    
                    // Set up event handler for number of travelers change
                    numericUpDownNumberOfTravelers.ValueChanged += (s, e) => CalculateTotal();
                }
                else
                {
                    MessageBox.Show("Failed to load client or package information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading reservation data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }
        
        private void CalculateTotal()
        {
            if (_package != null)
            {
                var numberOfTravelers = (int)numericUpDownNumberOfTravelers.Value;
                var totalPrice = _package.Price * numberOfTravelers;
                textBoxTotalPrice.Text = totalPrice.ToString("C");
            }
        }
        
        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                try
                {
                    var numberOfTravelers = (int)numericUpDownNumberOfTravelers.Value;
                    _ = Task.Run(async () =>
                    {
                        // Create reservation object
                        var reservation = new Reservation
                        {
                            ClientId = _clientId,
                            PackageId = _packageId,
                            ReservationDate = DateTime.Now,
                            NumberOfTravelers = numberOfTravelers,
                            TotalPrice = _package!.Price * numberOfTravelers,
                            Status = ReservationStatus.Active
                        };
                        
                        // Create and execute command
                        var command = new ReservePackageCommand(_agencyService.GetDatabaseAdapter(), reservation);
                        var success = await _commandInvoker.ExecuteCommandAsync(command);
                        
                        if (InvokeRequired)
                        {
                            Invoke(new Action(() =>
                            {
                                if (success)
                                {
                                    MessageBox.Show("Reservation confirmed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    DialogResult = DialogResult.OK;
                                    Close();
                                }
                                else
                                {
                                    MessageBox.Show("Failed to confirm reservation.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }));
                        }
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error confirming reservation: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        private bool ValidateInput()
        {
            if (_client == null || _package == null)
            {
                MessageBox.Show("Client or package information is missing.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
            var numberOfTravelers = (int)numericUpDownNumberOfTravelers.Value;
            if (numberOfTravelers <= 0)
            {
                MessageBox.Show("Number of travelers must be greater than zero.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
            return true;
        }
        
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
