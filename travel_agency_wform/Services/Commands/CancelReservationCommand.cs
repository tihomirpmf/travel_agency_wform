using travel_agency_wform.Models;

namespace travel_agency_wform.Services.Commands
{
    public class CancelReservationCommand : ICommand
    {
        private readonly TravelAgencyService _service;
        private readonly int _reservationId;
        private ReservationStatus _originalStatus;
        private bool _wasExecuted = false;
        
        public CancelReservationCommand(TravelAgencyService service, int reservationId)
        {
            _service = service;
            _reservationId = reservationId;
        }
        
        public string Description => $"Cancel reservation ID: {_reservationId}";
        
        public async Task<bool> ExecuteAsync()
        {
            try
            {
                // Get the current reservation to store original status
                var reservation = await _service.GetReservationByIdAsync(_reservationId);
                if (reservation == null)
                    return false;
                
                _originalStatus = reservation.Status;
                
                // Cancel the reservation
                var success = await _service.CancelReservationAsync(_reservationId);
                _wasExecuted = success;
                return success;
            }
            catch
            {
                return false;
            }
        }
        
        public async Task<bool> UndoAsync()
        {
            if (!_wasExecuted)
                return false;
                
            try
            {
                // Restore the original status
                var reservation = await _service.GetReservationByIdAsync(_reservationId);
                if (reservation == null)
                    return false;
                
                // Update the reservation status back to original
                reservation.Status = _originalStatus;
                return await _service.UpdateReservationAsync(reservation);
            }
            catch
            {
                return false;
            }
        }
    }
}
