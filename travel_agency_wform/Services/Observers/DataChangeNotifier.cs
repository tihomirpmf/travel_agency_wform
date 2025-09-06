using System.Collections.Concurrent;

namespace travel_agency_wform.Services.Observers
{
    public class DataChangeNotifier
    {
        private static readonly Lazy<DataChangeNotifier> _instance = 
            new Lazy<DataChangeNotifier>(() => new DataChangeNotifier());
        
        public static DataChangeNotifier Instance => _instance.Value;
        
        private readonly ConcurrentBag<IDataObserver> _observers = new();
        
        private DataChangeNotifier() { }
        
        public void Subscribe(IDataObserver observer)
        {
            if (observer != null && !_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
        }
        
        public void Unsubscribe(IDataObserver observer)
        {
            if (observer != null)
            {
                var tempObservers = new ConcurrentBag<IDataObserver>(_observers.Where(o => o != observer));
                _observers.Clear();
                foreach (var obs in tempObservers)
                {
                    _observers.Add(obs);
                }
            }
        }
        
        public void NotifyClientAdded(int clientId)
        {
            foreach (var observer in _observers)
            {
                try
                {
                    observer.OnClientAdded(clientId);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error notifying observer: {ex.Message}");
                }
            }
        }
        
        public void NotifyPackageAdded(int packageId)
        {
            foreach (var observer in _observers)
            {
                try
                {
                    observer.OnPackageAdded(packageId);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error notifying observer: {ex.Message}");
                }
            }
        }
        
        public void NotifyReservationAdded(int reservationId)
        {
            foreach (var observer in _observers)
            {
                try
                {
                    observer.OnReservationAdded(reservationId);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error notifying observer: {ex.Message}");
                }
            }
        }
        
        public void NotifyReservationUpdated(int reservationId)
        {
            foreach (var observer in _observers)
            {
                try
                {
                    observer.OnReservationUpdated(reservationId);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error notifying observer: {ex.Message}");
                }
            }
        }
        
        public void NotifyReservationCancelled(int reservationId)
        {
            foreach (var observer in _observers)
            {
                try
                {
                    observer.OnReservationCancelled(reservationId);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error notifying observer: {ex.Message}");
                }
            }
        }
    }
}
