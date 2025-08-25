namespace travel_agency_wform.Services.Observers
{
    public interface IDataObserver
    {
        void OnDataChanged(string dataType);
        void OnClientAdded(int clientId);
        void OnClientUpdated(int clientId);
        void OnClientDeleted(int clientId);
        void OnPackageAdded(int packageId);
        void OnPackageUpdated(int packageId);
        void OnPackageDeleted(int packageId);
        void OnReservationAdded(int reservationId);
        void OnReservationUpdated(int reservationId);
        void OnReservationCancelled(int reservationId);
    }
}
