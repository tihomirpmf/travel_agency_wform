using travel_agency_wform.Models;
using travel_agency_wform.Services;
using travel_agency_wform.Services.Observers;
using travel_agency_wform.Forms;

namespace travel_agency_wform
{
    public partial class Form1 : Form, IDataObserver
    {
        private readonly ITravelAgencyService _agencyService;
        private readonly DataChangeNotifier _dataNotifier;

        private List<Client> _clients = new();
        private List<TravelPackage> _packages = new();
        private List<Reservation> _reservations = new();
        private Client? _selectedClient;

        public Form1()
        {
            InitializeComponent();

            _agencyService = new TravelAgencyService();
            _dataNotifier = DataChangeNotifier.Instance;

            // Subscribe to data changes
            _dataNotifier.Subscribe(this);

            // Wire reservation edit on double-click
            this.listBoxReservations.DoubleClick += listBoxReservations_DoubleClick;

            // Initialize the form
            InitializeFormAsync();

        }

        private async void InitializeFormAsync()
        {
            try
            {
                this.Text = "Initializing...";

                // Initialize database
                var success = await _agencyService.InitializeAsync();
                if (!success)
                {
                    MessageBox.Show("Failed to initialize database. Check if the application has write permissions in the current directory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Text = "Travel Agency - Database Error";
                    return;
                }

                // Set agency name
                this.Text = _agencyService.GetAgencyName();

                // Load initial data
                await LoadAllDataAsync();

                // Set up automatic backup timer (every 24 hours)
                var backupTimer = new System.Windows.Forms.Timer();
                backupTimer.Interval = 24 * 60 * 60 * 1000; // 24 hours in milliseconds
                backupTimer.Tick += async (s, e) => await _agencyService.CreateBackupAsync();
                backupTimer.Start();

                // Create backup on startup
                await _agencyService.CreateBackupAsync();

                MessageBox.Show("Application initialized successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing application: {ex.Message}\n\nStack trace: {ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Text = "Travel Agency - Error";
            }
        }

        private async Task LoadAllDataAsync()
        {
            try
            {
                _clients = await _agencyService.GetAllClientsAsync();
                _packages = await _agencyService.GetAllPackagesAsync();
                _reservations = await _agencyService.GetAllReservationsAsync();

                RefreshClientList();
                RefreshPackageList();
                RefreshReservationList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshClientList()
        {
            listBoxClients.Items.Clear();
            foreach (var client in _clients.OrderBy(c => c.LastName).ThenBy(c => c.FirstName))
            {
                listBoxClients.Items.Add($"{client.FullName} - {client.PassportNumber}");
            }
        }

        private void RefreshPackageList()
        {
            listBoxPackages.Items.Clear();

            // Group packages by type
            var seasidePackages = _packages.Where(p => p.Type == PackageType.Seaside).ToList();
            var mountainPackages = _packages.Where(p => p.Type == PackageType.Mountain).ToList();
            var excursionPackages = _packages.Where(p => p.Type == PackageType.Excursion).ToList();
            var cruisePackages = _packages.Where(p => p.Type == PackageType.Cruise).ToList();

            if (seasidePackages.Any())
            {
                listBoxPackages.Items.Add("=== SEASIDE PACKAGES ===");
                foreach (var package in seasidePackages)
                {
                    // Store the package object directly in the list box for easy access
                    listBoxPackages.Items.Add(package);
                }
            }

            if (mountainPackages.Any())
            {
                listBoxPackages.Items.Add("=== MOUNTAIN PACKAGES ===");
                foreach (var package in mountainPackages)
                {
                    // Store the package object directly in the list box for easy access
                    listBoxPackages.Items.Add(package);
                }
            }

            if (excursionPackages.Any())
            {
                listBoxPackages.Items.Add("=== EXCURSION PACKAGES ===");
                foreach (var package in excursionPackages)
                {
                    // Store the package object directly in the list box for easy access
                    listBoxPackages.Items.Add(package);
                }
            }

            if (cruisePackages.Any())
            {
                listBoxPackages.Items.Add("=== CRUISE PACKAGES ===");
                foreach (var package in cruisePackages)
                {
                    // Store the package object directly in the list box for easy access
                    listBoxPackages.Items.Add(package);
                }
            }
        }

        private void RefreshReservationList()
        {
            listBoxReservations.Items.Clear();
            if (_selectedClient != null)
            {
                var clientReservations = _reservations.Where(r => r.ClientId == _selectedClient.Id).ToList();
                System.Diagnostics.Debug.WriteLine($"Refreshing reservations for client {_selectedClient.Id}. Found {clientReservations.Count} reservations.");
                
                foreach (var reservation in clientReservations.OrderByDescending(r => r.ReservationDate))
                {
                    var package = _packages.FirstOrDefault(p => p.Id == reservation.PackageId);
                    var status = reservation.Status == ReservationStatus.Active ? "Active" :
                                reservation.Status == ReservationStatus.Cancelled ? "Cancelled" : "Completed";

                    System.Diagnostics.Debug.WriteLine($"Adding reservation: ID={reservation.Id}, Package={package?.Name ?? "Unknown"}, Status={status}");
                    
                    // Assign the package object to the reservation for the edit form
                    reservation.Package = package ?? new SeasidePackage { Name = "Unknown Package" };
                    
                    // Store the reservation object directly in the list box for easy access
                    listBoxReservations.Items.Add(reservation);
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("No client selected, clearing reservation list");
            }
        }





        // Observer pattern implementation
        public void OnDataChanged(string dataType)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(OnDataChanged), dataType);
                return;
            }

            _ = LoadAllDataAsync();
        }

        public void OnClientAdded(int clientId) => OnDataChanged("clients");
        public void OnPackageAdded(int packageId) => OnDataChanged("packages");
        public void OnReservationAdded(int reservationId) => OnDataChanged("reservations");
        public void OnReservationUpdated(int reservationId) => OnDataChanged("reservations");
        public void OnReservationCancelled(int reservationId) => OnDataChanged("reservations");

        // Event handlers
        private void listBoxClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxClients.SelectedIndex >= 0 && listBoxClients.SelectedItem != null)
            {
                var selectedText = listBoxClients.SelectedItem?.ToString() ?? "";
                var passportNumber = selectedText.Split(" - ").Last();
                _selectedClient = _clients.FirstOrDefault(c => c.PassportNumber == passportNumber);

                if (_selectedClient != null)
                {
                    RefreshReservationList();
                    groupBoxClientInfo.Visible = true;
                    textBoxClientName.Text = _selectedClient.FullName;
                    textBoxClientEmail.Text = _selectedClient.Email;
                    textBoxClientPhone.Text = _selectedClient.PhoneNumber;
                }
            }
        }

        private void buttonAddClient_Click(object sender, EventArgs e)
        {
            var addClientForm = new AddClientForm(_agencyService);
            if (addClientForm.ShowDialog() == DialogResult.OK)
            {
                // Data will be refreshed via observer pattern
            }
        }

        private void buttonAddPackage_Click(object sender, EventArgs e)
        {
            var addPackageForm = new AddPackageForm(_agencyService);
            if (addPackageForm.ShowDialog() == DialogResult.OK)
            {
                // Data will be refreshed via observer pattern
            }
        }

        private void buttonReservePackage_Click(object sender, EventArgs e)
        {
            if (_selectedClient == null)
            {
                MessageBox.Show("Please select a client first.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (listBoxPackages.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a package to reserve.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedItem = listBoxPackages.SelectedItem;
            if (selectedItem is string selectedText && selectedText.StartsWith("==="))
            {
                MessageBox.Show("Please select a specific package, not a category header.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Get the selected package object directly
            var package = selectedItem as TravelPackage;
            if (package != null)
            {
                System.Diagnostics.Debug.WriteLine($"Opening reservation form for Client ID: {_selectedClient.Id}, Package ID: {package.Id}");
                var reservationForm = new ReservationForm(_agencyService, _selectedClient.Id, package.Id);
                if (reservationForm.ShowDialog() == DialogResult.OK)
                {
                    System.Diagnostics.Debug.WriteLine("Reservation form closed with OK result");
                    // Data will be refreshed via observer pattern
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Reservation form closed with Cancel result");
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine($"Invalid package selection: {selectedItem?.GetType().Name ?? "null"}");
                MessageBox.Show("Invalid package selection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancelReservation_Click(object sender, EventArgs e)
        {
            if (listBoxReservations.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a reservation to cancel.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (_selectedClient == null)
                return;

            // Get the selected reservation object directly
            var selectedReservation = listBoxReservations.SelectedItem as Reservation;
            if (selectedReservation == null)
            {
                MessageBox.Show("Invalid reservation selection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if the reservation is already cancelled
            if (selectedReservation.Status != ReservationStatus.Active)
            {
                MessageBox.Show("Only active reservations can be cancelled.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show($"Are you sure you want to cancel the reservation for {selectedReservation.Package?.Name ?? "Unknown"}?",
                "Confirm Cancellation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _ = Task.Run(async () =>
                {
                    try
                    {
                        var success = await _agencyService.CancelReservationAsync(selectedReservation.Id);

                        if (InvokeRequired)
                        {
                            Invoke(new Action(() =>
                            {
                                if (success)
                                {
                                    MessageBox.Show("Reservation cancelled successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    // Refresh the data to show the updated status
                                    _ = LoadAllDataAsync();
                                }
                                else
                                {
                                    MessageBox.Show("Failed to cancel reservation.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }));
                        }
                    }
                    catch (Exception ex)
                    {
                        if (InvokeRequired)
                        {
                            Invoke(new Action(() =>
                            {
                                MessageBox.Show($"Error cancelling reservation: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }));
                        }
                    }
                });
            }
        }

        private void listBoxReservations_DoubleClick(object? sender, EventArgs e)
        {
            var reservation = listBoxReservations.SelectedItem as Reservation;
            if (reservation == null)
                return;
            var editForm = new ReservationEditForm(_agencyService, reservation);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                // Data will be refreshed via observer pattern
            }
        }



        private void buttonSearch_Click(object sender, EventArgs e)
        {
            var searchTerm = textBoxSearch.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(searchTerm))
            {
                RefreshClientList();
                return;
            }

            var filteredClients = _clients.Where(c =>
                c.FirstName.ToLower().Contains(searchTerm) ||
                c.LastName.ToLower().Contains(searchTerm) ||
                c.PassportNumber.ToLower().Contains(searchTerm)).ToList();

            listBoxClients.Items.Clear();
            foreach (var client in filteredClients)
            {
                listBoxClients.Items.Add($"{client.FullName} - {client.PassportNumber}");
            }
        }

        private void buttonBackup_Click(object sender, EventArgs e)
        {
            _ = Task.Run(async () =>
            {
                var success = await _agencyService.CreateBackupAsync();
                if (InvokeRequired)
                {
                    Invoke(new Action(() =>
                    {
                        if (success)
                            MessageBox.Show("Database backup created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Failed to create database backup.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));
                }
            });
        }

        private void buttonViewDestinations_Click(object sender, EventArgs e)
        {
            var dlg = new DestinationsForm(_agencyService);
            dlg.ShowDialog(this);
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
