using travel_agency_wform.Services;

namespace travel_agency_wform.Forms
{
    public partial class DestinationsForm : Form
    {
        private readonly TravelAgencyService _service;
        
        public DestinationsForm(TravelAgencyService service)
        {
            _service = service;
            InitializeComponent();
        }
        
        private void InitializeComponent()
        {
            this.Text = "Available Destinations";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Width = 420;
            this.Height = 480;
            
            var list = new ListBox { Left = 10, Top = 10, Width = 380, Height = 380 };
            var buttonClose = new Button { Left = 270, Top = 400, Width = 120, Text = "Close" };
            buttonClose.Click += (s, e) => this.Close();
            
            this.Controls.Add(list);
            this.Controls.Add(buttonClose);
            
            this.Load += async (s, e) =>
            {
                try
                {
                    var destinations = await _service.GetAllDestinationsAsync();
                    list.Items.Clear();
                    foreach (var d in destinations)
                    {
                        list.Items.Add(d);
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


