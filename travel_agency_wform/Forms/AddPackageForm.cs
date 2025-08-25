using travel_agency_wform.Models;
using travel_agency_wform.Services;

namespace travel_agency_wform.Forms
{
    public partial class AddPackageForm : Form
    {
        private readonly TravelAgencyService _agencyService;
        
        public AddPackageForm(TravelAgencyService agencyService)
        {
            InitializeComponent();
            _agencyService = agencyService;
            
            // Set up package type combo box
            comboBoxPackageType.DataSource = Enum.GetValues(typeof(PackageType));
            comboBoxPackageType.SelectedIndex = 0;
            
            // Set up numeric up down controls
            numericUpDownPrice.Minimum = 1;
            numericUpDownPrice.Maximum = 100000;
            numericUpDownPrice.Value = 1000;
            
            numericUpDownNumberOfDays.Minimum = 1;
            numericUpDownNumberOfDays.Maximum = 365;
            numericUpDownNumberOfDays.Value = 7;
            
            numericUpDownNumberOfTravelers.Minimum = 1;
            numericUpDownNumberOfTravelers.Maximum = 100;
            numericUpDownNumberOfTravelers.Value = 1;
            
            // Set up date picker
            dateTimePickerCruiseDepartureDate.MinDate = DateTime.Today;
            dateTimePickerCruiseDepartureDate.Value = DateTime.Today.AddDays(30);
            
            // Show/hide controls based on package type
            comboBoxPackageType.SelectedIndexChanged += ComboBoxPackageType_SelectedIndexChanged;
            ComboBoxPackageType_SelectedIndexChanged(null, null);
        }
        
        private void ComboBoxPackageType_SelectedIndexChanged(object? sender, EventArgs? e)
        {
            var selectedType = (PackageType)comboBoxPackageType.SelectedItem;
            
            // Hide all type-specific panels first
            panelSeaside.Visible = false;
            panelMountain.Visible = false;
            panelExcursion.Visible = false;
            panelCruise.Visible = false;
            
            // Show appropriate panel
            switch (selectedType)
            {
                case PackageType.Seaside:
                    panelSeaside.Visible = true;
                    break;
                case PackageType.Mountain:
                    panelMountain.Visible = true;
                    break;
                case PackageType.Excursion:
                    panelExcursion.Visible = true;
                    break;
                case PackageType.Cruise:
                    panelCruise.Visible = true;
                    break;
            }
        }
        
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                try
                {
                    var packageType = (PackageType)comboBoxPackageType.SelectedItem;
                    TravelPackage package;
                    
                    switch (packageType)
                    {
                        case PackageType.Seaside:
                            package = new SeasidePackage
                            {
                                Name = textBoxPackageName.Text.Trim(),
                                Price = numericUpDownPrice.Value,
                                Type = packageType,
                                Destination = textBoxDestination.Text.Trim(),
                                NumberOfDays = (int)numericUpDownNumberOfDays.Value,
                                AccommodationType = textBoxSeasideAccommodationType.Text.Trim(),
                                TransportationType = textBoxSeasideTransportationType.Text.Trim()
                            };
                            break;
                            
                        case PackageType.Mountain:
                            var activities = textBoxMountainActivities.Text.Split(',', StringSplitOptions.RemoveEmptyEntries)
                                .Select(a => a.Trim()).ToList();
                            package = new MountainPackage
                            {
                                Name = textBoxPackageName.Text.Trim(),
                                Price = numericUpDownPrice.Value,
                                Type = packageType,
                                Destination = textBoxDestination.Text.Trim(),
                                NumberOfDays = (int)numericUpDownNumberOfDays.Value,
                                AccommodationType = textBoxMountainAccommodationType.Text.Trim(),
                                TransportationType = textBoxMountainTransportation.Text.Trim(),
                                Activities = activities
                            };
                            break;
                            
                        case PackageType.Excursion:
                            package = new ExcursionPackage
                            {
                                Name = textBoxPackageName.Text.Trim(),
                                Price = numericUpDownPrice.Value,
                                Type = packageType,
                                Destination = textBoxDestination.Text.Trim(),
                                NumberOfDays = (int)numericUpDownNumberOfDays.Value,
                                TransportationType = textBoxExcursionTransportation.Text.Trim(),
                                Guide = textBoxExcursionGuide.Text.Trim()
                            };
                            break;
                            
                        case PackageType.Cruise:
                            package = new CruisePackage
                            {
                                Name = textBoxPackageName.Text.Trim(),
                                Price = numericUpDownPrice.Value,
                                Type = packageType,
                                Destination = textBoxDestination.Text.Trim(),
                                NumberOfDays = (int)numericUpDownNumberOfDays.Value,
                                Ship = textBoxCruiseShip.Text.Trim(),
                                Route = textBoxCruiseRoute.Text.Trim(),
                                DepartureDate = dateTimePickerCruiseDepartureDate.Value.Date,
                                CabinType = textBoxCruiseCabinType.Text.Trim(),
                                TransportationType = textBoxCruiseTransportation.Text.Trim()
                            };
                            break;
                            
                        default:
                            throw new ArgumentException("Invalid package type");
                    }
                    
                    _ = Task.Run(async () =>
                    {
                        var packageId = await _agencyService.AddPackageAsync(package);
                        if (InvokeRequired)
                        {
                            Invoke(new Action(() =>
                            {
                                if (packageId > 0)
                                {
                                    MessageBox.Show("Package added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    DialogResult = DialogResult.OK;
                                    Close();
                                }
                                else
                                {
                                    MessageBox.Show("Failed to add package.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }));
                        }
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding package: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(textBoxPackageName.Text))
            {
                MessageBox.Show("Package name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxPackageName.Focus();
                return false;
            }
            
            if (string.IsNullOrWhiteSpace(textBoxDestination.Text))
            {
                MessageBox.Show("Destination is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxDestination.Focus();
                return false;
            }
            
            var packageType = (PackageType)comboBoxPackageType.SelectedItem;
            
            switch (packageType)
            {
                case PackageType.Seaside:
                    if (string.IsNullOrWhiteSpace(textBoxSeasideAccommodationType.Text))
                    {
                        MessageBox.Show("Accommodation type is required for seaside packages.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBoxSeasideAccommodationType.Focus();
                        return false;
                    }
                    if (string.IsNullOrWhiteSpace(textBoxSeasideTransportationType.Text))
                    {
                        MessageBox.Show("Transportation type is required for seaside packages.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBoxSeasideTransportationType.Focus();
                        return false;
                    }
                    break;
                    
                case PackageType.Mountain:
                    if (string.IsNullOrWhiteSpace(textBoxMountainAccommodationType.Text))
                    {
                        MessageBox.Show("Accommodation type is required for mountain packages.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBoxMountainAccommodationType.Focus();
                        return false;
                    }
                    if (string.IsNullOrWhiteSpace(textBoxMountainTransportation.Text))
                    {
                        MessageBox.Show("Transportation type is required for mountain packages.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBoxMountainTransportation.Focus();
                        return false;
                    }
                    if (string.IsNullOrWhiteSpace(textBoxMountainActivities.Text))
                    {
                        MessageBox.Show("Activities are required for mountain packages.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBoxMountainActivities.Focus();
                        return false;
                    }
                    break;
                    
                case PackageType.Excursion:
                    if (string.IsNullOrWhiteSpace(textBoxExcursionTransportation.Text))
                    {
                        MessageBox.Show("Transportation type is required for excursion packages.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBoxExcursionTransportation.Focus();
                        return false;
                    }
                    if (string.IsNullOrWhiteSpace(textBoxExcursionGuide.Text))
                    {
                        MessageBox.Show("Guide is required for excursion packages.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBoxExcursionGuide.Focus();
                        return false;
                    }
                    break;
                    
                case PackageType.Cruise:
                    if (string.IsNullOrWhiteSpace(textBoxCruiseShip.Text))
                    {
                        MessageBox.Show("Ship name is required for cruise packages.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBoxCruiseShip.Focus();
                        return false;
                    }
                    if (string.IsNullOrWhiteSpace(textBoxCruiseRoute.Text))
                    {
                        MessageBox.Show("Route is required for cruise packages.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBoxCruiseRoute.Focus();
                        return false;
                    }
                    if (string.IsNullOrWhiteSpace(textBoxCruiseCabinType.Text))
                    {
                        MessageBox.Show("Cabin type is required for cruise packages.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBoxCruiseCabinType.Focus();
                        return false;
                    }
                    break;
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
