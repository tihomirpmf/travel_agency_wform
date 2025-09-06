using travel_agency_wform.Services;

namespace travel_agency_wform.Forms
{
    public partial class DestinationsForm : Form
    {
        private readonly ITravelAgencyFacade _agencyService = null!;

        public DestinationsForm()
        {
            InitializeComponent();
        }

        public DestinationsForm(ITravelAgencyFacade service)
        {
            InitializeComponent();
            _agencyService = service;
            InitializeRuntimeBindings();
        }

        private void InitializeRuntimeBindings()
        {
            buttonClose.Click += (s, e) => this.Close();

            this.Load += async (s, e) =>
            {
                try
                {
                    var destinations = await _agencyService.GetAllDestinationsAsync();
                    listBoxDestinations.Items.Clear();
                    foreach (var d in destinations)
                    {
                        listBoxDestinations.Items.Add(d);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to load destinations: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
        }
    }
}


