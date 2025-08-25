# Travel Agency Management System

A comprehensive .NET Windows Forms application for managing travel agencies, built using multiple design patterns to demonstrate software architecture best practices.

## Features

### Core Functionality
- **Client Management**: Add, update, delete, and search clients with full validation
- **Travel Package Management**: Create and manage different types of travel packages
- **Reservation System**: Book packages for clients with real-time pricing calculation
- **Database Operations**: Full CRUD operations with automatic backup system
- **Search & Filter**: Advanced client search by name, surname, or passport number

### Package Types Supported
- **Seaside Packages**: Beach destinations with accommodation and transportation
- **Mountain Packages**: Mountain destinations with activities and accommodation
- **Excursion Packages**: Guided tours with transportation
- **Cruise Packages**: Ship-based travel with cabin types and routes

## Design Patterns Implemented

### Creational Patterns (3 required)
1. **Singleton Pattern** (Mandatory)
   - `ConfigurationManager`: Ensures single instance manages application configuration
   - Lazy initialization with thread safety
   - Manages config.txt file for agency name and database connection

2. **Factory Method Pattern**
   - `DatabaseFactory`: Creates appropriate database connections
   - `SqliteConnectionFactory`: SQLite database implementation
   - `MySqlConnectionFactory`: MySQL database implementation
   - Automatic database type detection from connection string

3. **Builder Pattern**
   - `IPackageBuilder`: Interface for building travel packages
   - `SeasidePackageBuilder`: Constructs seaside packages step-by-step
   - `MountainPackageBuilder`: Constructs mountain packages with activities
   - `ExcursionPackageBuilder`: Constructs excursion packages with guides
   - `CruisePackageBuilder`: Constructs cruise packages with ships and routes
   - Fluent API for complex object construction

### Structural Patterns (2 required)
1. **Adapter Pattern** (from first group)
   - `IDatabaseAdapter`: Unified interface for database operations
   - `SqliteDatabaseAdapter`: Adapts SQLite-specific operations to common interface
   - Supports multiple database providers seamlessly

2. **Facade Pattern** (from second group)
   - `TravelAgencyService`: Simplified interface to complex subsystems
   - Hides database operations, validation, and business logic complexity
   - Provides clean API for GUI operations

### Behavioral Patterns (2 required)
1. **Observer Pattern**
   - `IDataObserver`: Interface for GUI components to observe data changes
   - `DataChangeNotifier`: Notifies observers of real-time data updates
   - Automatic GUI refresh when data changes

2. **Command Pattern**
   - `ICommand`: Interface for database operations
   - `AddClientCommand`, `ReservePackageCommand`, `CancelReservationCommand`: Concrete command implementations
   - `CommandInvoker`: Manages command execution, undo, and redo functionality
   - **Full UI Integration**: Undo/Redo buttons with command history display
   - **Real-time Updates**: Command history updates after each operation
   - Maintains operation history for rollback capabilities

## Technical Architecture

### Database Support
- **SQLite**: Default embedded database for development and small deployments
- **MySQL**: Enterprise database support for production environments
- **Automatic Detection**: Connection string analysis for database type selection
- **Schema Management**: Automatic table creation and migration

### Data Models
- **Client**: Personal information with validation
- **TravelPackage**: Abstract base class with type-specific implementations
- **Reservation**: Links clients to packages with status tracking

### Security Features
- **Data Encryption**: AES-256 encryption for sensitive data (passport numbers, phone numbers)
- **Data Validation**: Comprehensive input validation and sanitization
- **Database Backup**: Automatic 24-hour backups with manual backup option
- **Error Handling**: Graceful error handling with user-friendly messages

## Installation & Setup

### Prerequisites
- .NET 8.0 or later
- Windows operating system
- Visual Studio 2022 or later (for development)

### Configuration
1. Create a `config.txt` file in the application directory:
   ```
   Travel Agency Name
   Data Source=travel_agency.db
   ```
2. For MySQL, use connection string format:
   ```
   Server=localhost;Database=travel_agency;Uid=username;Pwd=password;
   ```
3. The application automatically detects database type from connection string

### Building & Running
1. Clone the repository
2. Open `travel_agency_wform.sln` in Visual Studio
3. Restore NuGet packages
4. Build and run the application

## Usage

### Adding Clients
1. Click "Add New Client" button
2. Fill in all required fields (name, passport, email, etc.)
3. Click "Save" to add the client

### Creating Packages
1. Click "Add New Package" button
2. Select package type (Seaside, Mountain, Excursion, Cruise)
3. Fill in package-specific details
4. Set price and duration
5. Click "Save" to create the package

### Making Reservations
1. Select a client from the client list
2. Select a package from the package list
3. Click "Reserve Package"
4. Enter number of travelers
5. Confirm reservation

### Managing Reservations
- View client reservations by selecting a client
- Cancel reservations using the "Cancel Reservation" button
- Use Undo/Redo for operation history

## Project Structure

```
travel_agency_wform/
├── Models/                          # Domain models
│   ├── Client.cs                   # Client entity
│   ├── TravelPackage.cs            # Package hierarchy
│   └── Reservation.cs              # Reservation entity
├── Services/                       # Business logic services
│   ├── ConfigurationManager.cs     # Singleton configuration
│   ├── TravelAgencyService.cs     # Facade service
│   ├── Security/                   # Security layer
│   │   └── DataEncryptionService.cs # AES encryption for sensitive data
│   ├── Database/                   # Database layer
│   │   ├── IDatabaseAdapter.cs    # Database interface
│   │   ├── DatabaseFactory.cs     # Factory method
│   │   ├── SqliteDatabaseAdapter.cs
│   │   ├── MySqlDatabaseAdapter.cs
│   │   └── MySqlConnectionFactory.cs
│   ├── Builders/                   # Builder pattern
│   │   ├── IPackageBuilder.cs     # Builder interface
│   │   ├── SeasidePackageBuilder.cs
│   │   ├── MountainPackageBuilder.cs
│   │   ├── ExcursionPackageBuilder.cs
│   │   └── CruisePackageBuilder.cs
│   ├── Observers/                  # Observer pattern
│   │   ├── IDataObserver.cs       # Observer interface
│   │   └── DataChangeNotifier.cs  # Subject implementation
│   └── Commands/                   # Command pattern
│       ├── ICommand.cs            # Command interface
│       ├── CommandInvoker.cs      # Command invoker with undo/redo
│       ├── AddClientCommand.cs    # Add client command
│       ├── ReservePackageCommand.cs # Reserve package command
│       └── CancelReservationCommand.cs # Cancel reservation command
├── Forms/                          # Windows Forms
│   ├── AddClientForm.cs           # Client creation form
│   ├── AddPackageForm.cs          # Package creation form
│   └── ReservationForm.cs         # Reservation form
├── Form1.cs                       # Main application form
└── Program.cs                     # Application entry point
```

## Benefits of Design Patterns

### Singleton Pattern
- **Configuration Management**: Centralized configuration handling
- **Resource Control**: Single point of access to shared resources
- **Thread Safety**: Safe concurrent access to configuration

### Factory Method Pattern
- **Database Abstraction**: Easy switching between database providers
- **Extensibility**: Simple to add new database types
- **Configuration**: Runtime database selection based on connection string

### Builder Pattern
- **Complex Object Creation**: Step-by-step package construction for all 4 package types
- **Type-Specific Validation**: Built-in validation for each package type's requirements
- **Fluent API**: Readable and maintainable code with method chaining
- **Complete Coverage**: Support for Seaside, Mountain, Excursion, and Cruise packages

### Adapter Pattern
- **Database Independence**: Unified interface for different databases
- **Maintainability**: Easy to modify or extend database operations
- **Testing**: Simplified unit testing with mock adapters

### Facade Pattern
- **Simplified Interface**: Easy-to-use API for complex operations
- **Loose Coupling**: GUI components don't need to know implementation details
- **Maintainability**: Changes to business logic don't affect GUI

### Observer Pattern
- **Real-time Updates**: Automatic GUI refresh when data changes
- **Loose Coupling**: GUI components observe data without tight coupling
- **Scalability**: Easy to add new observers for different data types

### Command Pattern
- **Undo/Redo**: Full operation history and rollback capability
- **Transaction Management**: Atomic operations with rollback support
- **Audit Trail**: Complete record of all operations performed

### Data Encryption Service
- **AES-256 Encryption**: Military-grade encryption for sensitive data
- **Automatic Encryption**: Transparent encryption/decryption of passport numbers and phone numbers
- **Backward Compatibility**: Handles both encrypted and unencrypted legacy data
- **Security Compliance**: Meets data protection requirements for sensitive information

## Future Enhancements

- **Web API**: RESTful API for mobile and web clients
- **Advanced Reporting**: Comprehensive reporting and analytics
- **Payment Integration**: Online payment processing
- **Email Notifications**: Automated email confirmations
- **Multi-language Support**: Internationalization
- **Advanced Search**: Full-text search and filtering
- **Data Export**: CSV, PDF, and Excel export functionality

## Contributing

1. Fork the repository
2. Create a feature branch
3. Implement your changes
4. Add appropriate tests
5. Submit a pull request

## License

This project is licensed under the MIT License - see the LICENSE file for details.

## Support

For support and questions, please open an issue in the GitHub repository.