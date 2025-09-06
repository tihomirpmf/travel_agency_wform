using travel_agency_wform.Models;
using travel_agency_wform.Services;

namespace travel_agency_wform.Forms
{
    public partial class ReservationEditForm : Form
    {
        private readonly ITravelAgencyService _agencyService;
        private readonly Reservation _reservation;
        
        private ComboBox _comboPackages = null!;
        private ComboBox _comboStatus = null!;
        private NumericUpDown _numericTravelers = null!;
        private Label _labelTotal = null!;
        private NumericUpDown _numericPrice = null!;
        
        public ReservationEditForm(ITravelAgencyService service, Reservation reservation)
        {
            _agencyService = service;
            _reservation = reservation;
            InitializeComponent();
        }
        
        private void InitializeComponent()
        {
            this.Text = "Edit Reservation";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Width = 540;
            this.Height = 300;
            
            var labelPackage = new Label { Left = 20, Top = 20, Width = 150, Text = "Package:" };
            _comboPackages = new ComboBox { Left = 180, Top = 18, Width = 320, DropDownStyle = ComboBoxStyle.DropDownList };
            
            var labelStatus = new Label { Left = 20, Top = 55, Width = 150, Text = "Status:" };
            _comboStatus = new ComboBox { Left = 180, Top = 53, Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };
            _comboStatus.Items.AddRange(new object[] { ReservationStatus.Active, ReservationStatus.Cancelled });
            _comboStatus.SelectedItem = _reservation.Status;
            
            var labelTravelers = new Label { Left = 20, Top = 90, Width = 150, Text = "Number of travelers:" };
            _numericTravelers = new NumericUpDown { Left = 180, Top = 88, Width = 120, Minimum = 1, Maximum = 100 };
            _numericTravelers.Value = _reservation.NumberOfTravelers > 0 ? _reservation.NumberOfTravelers : 1;
            _numericTravelers.ValueChanged += (s, e) => UpdateTotalLabel();
            
            var labelPrice = new Label { Left = 20, Top = 125, Width = 150, Text = "Price per person:" };
            _numericPrice = new NumericUpDown { Left = 180, Top = 123, Width = 120, Minimum = 0, Maximum = 1000000, DecimalPlaces = 2, Increment = 1 };
            _numericPrice.ValueChanged += (s, e) => UpdateTotalLabel();
            
            _labelTotal = new Label { Left = 320, Top = 125, Width = 180, Text = "Total: -" };
            
            var buttonSave = new Button { Left = 380, Top = 210, Width = 120, Text = "Save" };
            buttonSave.Click += async (s, e) =>
            {
                try
                {
                    // apply edits
                    var selectedPackage = _comboPackages.SelectedItem as TravelPackage;
                    if (selectedPackage != null)
                    {
                        _reservation.PackageId = selectedPackage.Id;
                        _reservation.Package = selectedPackage;
                    }
                    _reservation.Status = (ReservationStatus)_comboStatus.SelectedItem!;
                    _reservation.NumberOfTravelers = (int)_numericTravelers.Value;

                    // set explicit total using price * travelers
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
            
            this.Controls.Add(labelPackage);
            this.Controls.Add(_comboPackages);
            this.Controls.Add(labelStatus);
            this.Controls.Add(_comboStatus);
            this.Controls.Add(labelTravelers);
            this.Controls.Add(_numericTravelers);
            this.Controls.Add(labelPrice);
            this.Controls.Add(_numericPrice);
            this.Controls.Add(_labelTotal);
            this.Controls.Add(buttonSave);
            
            var buttonDelete = new Button { Left = 20, Top = 210, Width = 120, Text = "Delete" };
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
            this.Controls.Add(buttonDelete);
            
            // async load packages
            this.Load += async (s, e) =>
            {
                try
                {
                    var packages = await _agencyService.GetAllPackagesAsync();
                    System.Diagnostics.Debug.WriteLine($"Loaded {packages.Count} packages for reservation {_reservation.Id} with PackageId {_reservation.PackageId}");
                    
                    _comboPackages.Items.Clear();
                    foreach (var p in packages)
                    {
                        _comboPackages.Items.Add(p);
                    }
                    _comboPackages.DisplayMember = nameof(TravelPackage.Name);
                    
                    // select current package by ID
                    var currentPackage = packages.FirstOrDefault(x => x.Id == _reservation.PackageId);
                    if (currentPackage != null)
                    {
                        _comboPackages.SelectedItem = currentPackage;
                        System.Diagnostics.Debug.WriteLine($"Selected package: {currentPackage.Name} (ID: {currentPackage.Id})");
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine($"Package with ID {_reservation.PackageId} not found in available packages");
                        _comboPackages.SelectedIndex = packages.Count > 0 ? 0 : -1;
                    }
                    
                    // initialize price from package
                    var initialPackage = _comboPackages.SelectedItem as TravelPackage;
                    if (initialPackage != null)
                    {
                        _numericPrice.Value = initialPackage.Price;
                    }
                    else
                    {
                        // Fallback to reservation's total price divided by number of travelers
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


