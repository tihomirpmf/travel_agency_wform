using travel_agency_wform.Models;

namespace travel_agency_wform.Services.Commands
{
    public class AddClientCommand : ICommand
    {
        private readonly TravelAgencyService _service;
        private readonly Client _client;
        private int _addedClientId = -1;
        
        public AddClientCommand(TravelAgencyService service, Client client)
        {
            _service = service;
            _client = client;
        }
        
        public string Description => $"Add client: {_client.FullName}";
        
        public async Task<bool> ExecuteAsync()
        {
            try
            {
                _addedClientId = await _service.AddClientAsync(_client);
                return _addedClientId > 0;
            }
            catch
            {
                return false;
            }
        }
        
        public async Task<bool> UndoAsync()
        {
            if (_addedClientId <= 0)
                return false;
                
            try
            {
                return await _service.DeleteClientAsync(_addedClientId);
            }
            catch
            {
                return false;
            }
        }
    }
}
