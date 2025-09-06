using travel_agency_wform.Models;
using travel_agency_wform.Services;

namespace travel_agency_wform.Forms
{
    public partial class ReservationEditForm : Form
    {
        private readonly ITravelAgencyFacade _agencyService = null!;
        private readonly Reservation _reservation = null!;

        public ReservationEditForm()
        {
            InitializeComponent();
        }

        public ReservationEditForm(ITravelAgencyFacade service, Reservation reservation)
        {
            InitializeComponent();
            _agencyService = service;
            _reservation = reservation;
            InitializeRuntimeBindings();
        }
        
        private void InitializeRuntimeBindings()
        {
            // Status options
            _comboStatus.Items.Clear();
            _comboStatus.Items.AddRange(new object[] { ReservationStatus.Active, ReservationStatus.Cancelled });
            _comboStatus.SelectedItem = _reservation.Status;

            // Travelers and price
            _numericTravelers.Minimum = 1;
            _numericTravelers.Maximum = 100;
            _numericTravelers.Value = _reservation.NumberOfTravelers > 0 ? _reservation.NumberOfTravelers : 1;
            _numericTravelers.ValueChanged += (s, e) => UpdateTotalLabel();

            _numericPrice.Minimum = 0;
            _numericPrice.Maximum = 1000000;
            _numericPrice.DecimalPlaces = 2;
            _numericPrice.Increment = 1;
            _numericPrice.ValueChanged += (s, e) => UpdateTotalLabel();

            // Save button
            buttonSave.Click += async (s, e) =>
            {
                try
                {
                    var selectedPackage = _comboPackages.SelectedItem as TravelPackage;
                    if (selectedPackage != null)
                    {
                        _reservation.PackageId = selectedPackage.Id;
                        _reservation.Package = selectedPackage;
                    }
                    _reservation.Status = (ReservationStatus)_comboStatus.SelectedItem!;
                    _reservation.NumberOfTravelers = (int)_numericTravelers.Value;

                    var perPerson = (decimal)_numericPrice.Value;
                    _reservation.TotalPrice = perPerson * _reservation.NumberOfTravelers;

                    var success = await _agencyService.UpdateReservationAsync(_reservation);
                    if (success)
                    {
                        MessageBox.Show("Reservation updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Failed to update reservation.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            // Delete button
            buttonDelete.Click += async (s, e) =>
            {
                try
                {
                    if (_reservation.Status != ReservationStatus.Cancelled)
                    {
                        MessageBox.Show("Only cancelled reservations can be deleted.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    var confirm = MessageBox.Show("Permanently delete this reservation?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (confirm != DialogResult.Yes) return;
                    var ok = await _agencyService.DeleteReservationAsync(_reservation.Id);
                    if (ok)
                    {
                        MessageBox.Show("Reservation deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete reservation.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            // Async load packages when form loads
            this.Load += async (s, e) =>
            {
                try
                {
                    var packages = await _agencyService.GetAllPackagesAsync();

                    _comboPackages.Items.Clear();
                    foreach (var p in packages)
                    {
                        _comboPackages.Items.Add(p);
                    }
                    _comboPackages.DisplayMember = nameof(TravelPackage.Name);

                    var currentPackage = packages.FirstOrDefault(x => x.Id == _reservation.PackageId);
                    if (currentPackage != null)
                    {
                        _comboPackages.SelectedItem = currentPackage;
                    }
                    else
                    {
                        _comboPackages.SelectedIndex = packages.Count > 0 ? 0 : -1;
                    }

                    var initialPackage = _comboPackages.SelectedItem as TravelPackage;
                    if (initialPackage != null)
                    {
                        _numericPrice.Value = initialPackage.Price;
                    }
                    else
                    {
                        if (_reservation.NumberOfTravelers > 0)
                        {
                            _numericPrice.Value = _reservation.TotalPrice / _reservation.NumberOfTravelers;
                        }
                    }
                    UpdateTotalLabel();

                    _comboPackages.SelectedIndexChanged += (sender, args) => UpdateTotalLabel();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to load packages: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
        }
        
        private void UpdateTotalLabel()
        {
            var selectedPackage = _comboPackages.SelectedItem as TravelPackage;
            var travelers = (int)_numericTravelers.Value;
            if (selectedPackage != null && travelers > 0)
            {
                var perPerson = (decimal)_numericPrice.Value;
                if (perPerson <= 0) perPerson = selectedPackage.Price;
                var total = perPerson * travelers;
                _labelTotal.Text = $"Total: {total:C2}";
            }
            else
            {
                _labelTotal.Text = "Total: -";
            }
        }
    }
}


