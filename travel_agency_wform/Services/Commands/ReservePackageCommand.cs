using travel_agency_wform.Models;
using travel_agency_wform.Services.Database;

namespace travel_agency_wform.Services.Commands
{
    public class ReservePackageCommand : ICommand
    {
        private readonly IDatabaseAdapter _databaseAdapter;
        private readonly Reservation _reservation;
        private int _addedReservationId = -1;
        
        public ReservePackageCommand(IDatabaseAdapter databaseAdapter, Reservation reservation)
        {
            _databaseAdapter = databaseAdapter;
            _reservation = reservation;
        }
        
        public string Description => $"Reserve package: {_reservation.Package?.Name} for {_reservation.Client?.FullName}";
        
        public async Task<bool> ExecuteAsync()
        {
            try
            {
                _addedReservationId = await _databaseAdapter.AddReservationAsync(_reservation);
                return _addedReservationId > 0;
            }
            catch
            {
                return false;
            }
        }
        
        public async Task<bool> UndoAsync()
        {
            if (_addedReservationId <= 0)
                return false;
                
            try
            {
                return await _databaseAdapter.CancelReservationAsync(_addedReservationId);
            }
            catch
            {
                return false;
            }
        }
    }
}
