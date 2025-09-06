using travel_agency_wform.Models;

namespace travel_agency_wform.Services.Builders
{
    public class ReservationBuilder
    {
        private int _id;
        private int _clientId;
        private int _packageId;
        private int _numberOfTravelers;
        private decimal _totalPrice;
        private ReservationStatus _status;
        private Client _client = new Client();
        private TravelPackage _package = new SeasidePackage();

        public ReservationBuilder SetId(int id)
        {
            _id = id;
            return this;
        }

        public ReservationBuilder SetClientId(int clientId)
        {
            _clientId = clientId;
            return this;
        }

        public ReservationBuilder SetPackageId(int packageId)
        {
            _packageId = packageId;
            return this;
        }

        public ReservationBuilder SetNumberOfTravelers(int numberOfTravelers)
        {
            _numberOfTravelers = numberOfTravelers;
            return this;
        }

        public ReservationBuilder SetTotalPrice(decimal totalPrice)
        {
            _totalPrice = totalPrice;
            return this;
        }

        public ReservationBuilder SetStatus(ReservationStatus status)
        {
            _status = status;
            return this;
        }

        public ReservationBuilder SetClient(Client client)
        {
            _client = client;
            return this;
        }

        public ReservationBuilder SetPackage(TravelPackage package)
        {
            _package = package;
            return this;
        }

        public Reservation Build()
        {
            return new Reservation
            {
                Id = _id,
                ClientId = _clientId,
                PackageId = _packageId,
                NumberOfTravelers = _numberOfTravelers,
                TotalPrice = _totalPrice,
                Status = _status,
                Client = _client,
                Package = _package
            };
        }
    }
}
