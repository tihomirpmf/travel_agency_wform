# Design Patterns in Travel Agency Application

This document outlines the design patterns implemented in the Travel Agency Windows Forms application.

## 1. Singleton Pattern

**Purpose**: Ensure only one instance of a class exists throughout the application lifecycle.

**Implementation**:
- `ConfigurationManager` - Manages application configuration settings
- `DataChangeNotifier` - Central notification system for data changes
- `CommandInvoker` - Manages command execution and undo/redo functionality
- `DataEncryptionService` - Provides encryption/decryption services

**Benefits**: 
- Centralized access to shared resources
- Consistent state management
- Memory efficiency

## 2. Builder Pattern

**Purpose**: Construct complex objects step by step, allowing for flexible object creation.

**Implementation**:
- `IPackageBuilder` interface and concrete builders:
  - `SeasidePackageBuilder`
  - `MountainPackageBuilder` 
  - `ExcursionPackageBuilder`
  - `CruisePackageBuilder`

**Benefits**:
- Fluent API for object construction
- Encapsulates complex object creation logic
- Supports different package types with specific properties

## 3. Command Pattern

**Purpose**: Encapsulate requests as objects, allowing for parameterization, queuing, and undo operations.

**Implementation**:
- `ICommand` interface
- Concrete commands: `AddClientCommand`, `ReservePackageCommand`, `CancelReservationCommand`
- `CommandInvoker` - Manages command execution with undo/redo stacks

**Benefits**:
- Supports undo/redo functionality
- Decouples request sender from request handler
- Enables command queuing and logging

## 4. Observer Pattern

**Purpose**: Define a one-to-many dependency between objects so that when one object changes state, all dependents are notified.

**Implementation**:
- `IDataObserver` interface
- `DataChangeNotifier` (Subject) - Manages observer subscriptions and notifications
- `Form1` implements `IDataObserver` to react to data changes

**Benefits**:
- Loose coupling between data and UI
- Automatic UI updates when data changes
- Extensible notification system

## 5. Abstract Factory Pattern

**Purpose**: Create families of related objects without specifying their concrete classes.

**Implementation**:
- `IDatabaseProviderFactory` interface
- Concrete factories: `SqliteProviderFactory`, `MySqlProviderFactory`
- `DatabaseFactory` - Creates appropriate factory based on connection string

**Benefits**:
- Database abstraction layer
- Easy switching between different database providers
- Consistent interface for different database types

## 6. Strategy Pattern

**Purpose**: Define a family of algorithms, encapsulate each one, and make them interchangeable.

**Implementation**:
- Database adapters: `IDatabaseAdapter`, `SqliteDatabaseAdapter`, `MySqlDatabaseAdapter`
- Backup strategies: `BackupTemplate`, `SqliteBackupTemplate`, `MySqlBackupTemplate`

**Benefits**:
- Runtime algorithm selection
- Easy addition of new database providers
- Consistent interface across different implementations

## 7. Template Method Pattern

**Purpose**: Define the skeleton of an algorithm in a base class, letting subclasses override specific steps.

**Implementation**:
- `BackupTemplate` abstract class
- Concrete implementations: `SqliteBackupTemplate`, `MySqlBackupTemplate`

**Benefits**:
- Code reuse across backup implementations
- Consistent backup process structure
- Easy extension for new backup types

## 8. Factory Method Pattern

**Purpose**: Define an interface for creating objects but let subclasses decide which class to instantiate.

**Implementation**:
- `DatabaseFactory.CreateProvider()` - Creates appropriate database provider factory
- Package builders in `TravelAgencyService` - Create specific package type builders

**Benefits**:
- Encapsulates object creation logic
- Supports runtime type selection
- Promotes loose coupling

## 9. Adapter Pattern

**Purpose**: Convert the interface of a class into another interface that clients expect.

**Implementation**:
- `IDatabaseAdapter` interface
- `BaseDatabaseAdapter` abstract class
- Concrete adapters: `SqliteDatabaseAdapter`, `MySqlDatabaseAdapter`

**Benefits**:
- Database abstraction layer
- Consistent interface for different database systems
- Easy integration of new database providers

## 10. Inheritance and Polymorphism

**Purpose**: Create a hierarchy of related classes with shared behavior.

**Implementation**:
- `TravelPackage` abstract base class
- Concrete package types: `SeasidePackage`, `MountainPackage`, `ExcursionPackage`, `CruisePackage`
- Each implements `GetPackageDetails()` method

**Benefits**:
- Code reuse through inheritance
- Polymorphic behavior for different package types
- Extensible package type system

## Pattern Usage Summary

| Pattern | Primary Use Case | Files |
|---------|------------------|-------|
| Singleton | Configuration, Notifications, Commands | ConfigurationManager, DataChangeNotifier, CommandInvoker, DataEncryptionService |
| Builder | Package Creation | IPackageBuilder, *PackageBuilder classes |
| Command | Undo/Redo Operations | ICommand, CommandInvoker, *Command classes |
| Observer | UI Updates | IDataObserver, DataChangeNotifier, Form1 |
| Abstract Factory | Database Provider Creation | IDatabaseProviderFactory, DatabaseFactory |
| Strategy | Database Operations | IDatabaseAdapter, *DatabaseAdapter classes |
| Template Method | Backup Operations | BackupTemplate, *BackupTemplate classes |
| Factory Method | Object Creation | DatabaseFactory, TravelAgencyService |
| Adapter | Database Abstraction | IDatabaseAdapter, *DatabaseAdapter classes |
| Inheritance | Package Types | TravelPackage, *Package classes |

## Benefits of Pattern Implementation

1. **Maintainability**: Clear separation of concerns and modular design
2. **Extensibility**: Easy to add new features and database providers
3. **Testability**: Interfaces and dependency injection enable unit testing
4. **Flexibility**: Runtime configuration and algorithm selection
5. **Code Reuse**: Common functionality shared across components
6. **Loose Coupling**: Components interact through well-defined interfaces
