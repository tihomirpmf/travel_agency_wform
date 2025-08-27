namespace travel_agency_wform.Services.Observers
{
    // Observer Pattern: Interface for objects that need to be notified of data changes
    // Purpose: Enables loose coupling between data sources and UI components
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
