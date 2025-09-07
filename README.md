# Design patterns coverage
Singleton (mandatory): Completed
ConfigurationManager, DataEncryptionService, DataChangeNotifier.
At least 2 other creational patterns: Completed
Builder: ClientBuilder, SeasidePackageBuilder, MountainPackageBuilder, ExcursionPackageBuilder, CruisePackageBuilder, ReservationBuilder.
Factory/Abstract Factory: DatabaseFactory + IDatabaseConnection with SqliteConnectionFactory/MySqlConnectionFactory.
At least 1 from Adapter/Proxy/Decorator: Completed
Adapter: IDatabaseAdapter with concrete SqliteDatabaseAdapter and MySqlDatabaseAdapter.
At least 1 from Bridge/Composite/Facade/Flyweight: Completed
Facade: TravelAgencyService provides a simple interface to database operations, builders, backup, and config.
At least 2 behavioral (excluding Iterator): Completed
Observer: DataChangeNotifier and IDataObserver with Form1 subscriber.
Template Method: BaseDatabaseAdapter (init, CRUD with DB-specific overrides), BackupTemplate.

# tihomir:
- ConfigurationManager, IDatabaseConnection, DatabaseFactory, MySqlConnectionFactory, SqliteConnectionFactory
- IDataOserver, DataChangeNotifier
- ITravelAgencyFacade, TravelAgencyFacade
- AddClientForm, AddClientForm.Designer

# ivan:
- Models., Builders.
- BackupTemplate, MySqlBackupTemplate, SqliteBackupTemplate
- DataEncryptionService
- Form1, Form1.Designer
- ReservationForm, ReservationForm.Designer

# mihailo:
- IDatabaseAdapter, BaseDatabaseAdapter, MySqlDatabaseAdapter, SqliteDatabaseAdapter
- AddPackageForm, AddPackageForm.Designer
- DestinationForm, DestinationForm.Designer
- ReservationEditForm, ReservationEditForm.Designer