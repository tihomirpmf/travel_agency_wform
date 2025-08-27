using travel_agency_wform.Models;

namespace travel_agency_wform.Services.Commands
{
    // Command Pattern: Concrete command for adding clients
    // Purpose: Encapsulates client addition operation for undo/redo support
    public class AddClientCommand : ICommand
    {
        private readonly ITravelAgencyService _service;
        private readonly Client _client;
        private int _addedClientId = -1;
        
        public AddClientCommand(ITravelAgencyService service, Client client)
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
            // Client deletion not supported, so undo is not possible
            return false;
        }
    }
}
