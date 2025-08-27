using travel_agency_wform.Models;

namespace travel_agency_wform.Services.Commands
{
    public class ReservePackageCommand : ICommand
    {
        private readonly TravelAgencyService _service;
        private readonly Reservation _reservation;
        private int _addedReservationId = -1;
        
        public ReservePackageCommand(TravelAgencyService service, Reservation reservation)
        {
            _service = service;
            _reservation = reservation;
        }
        
        public string Description => $"Reserve package: {_reservation.Package?.Name} for {_reservation.Client?.FullName}";
        
        public async Task<bool> ExecuteAsync()
        {
            try
            {
                _addedReservationId = await _service.ReservePackageAsync(_reservation.ClientId, _reservation.PackageId, _reservation.NumberOfTravelers);
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
                return await _service.CancelReservationAsync(_addedReservationId);
            }
            catch
            {
                return false;
            }
        }
    }
}
