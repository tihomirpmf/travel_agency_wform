using travel_agency_wform.Models;
using travel_agency_wform.Services.Database;

namespace travel_agency_wform.Services.Commands
{
    public class AddClientCommand : ICommand
    {
        private readonly IDatabaseAdapter _databaseAdapter;
        private readonly Client _client;
        private int _addedClientId = -1;
        
        public AddClientCommand(IDatabaseAdapter databaseAdapter, Client client)
        {
            _databaseAdapter = databaseAdapter;
            _client = client;
        }
        
        public string Description => $"Add client: {_client.FullName}";
        
        public async Task<bool> ExecuteAsync()
        {
            try
            {
                _addedClientId = await _databaseAdapter.AddClientAsync(_client);
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
                return await _databaseAdapter.DeleteClientAsync(_addedClientId);
            }
            catch
            {
                return false;
            }
        }
    }
}
