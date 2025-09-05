namespace travel_agency_wform.Services.Observers
{
    public interface IDataObserver
    {
        void OnDataChanged(string dataType);
        void OnClientAdded(int clientId);
        void OnPackageAdded(int packageId);
        void OnReservationAdded(int reservationId);
        void OnReservationUpdated(int reservationId);
        void OnReservationCancelled(int reservationId);
    }
}
