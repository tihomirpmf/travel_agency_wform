namespace travel_agency_wform.Services.Commands
{
    // Command Pattern: Interface for encapsulating requests as objects
    // Purpose: Enables undo/redo operations and decouples request sender from handler
    public interface ICommand
    {
        Task<bool> ExecuteAsync();
        Task<bool> UndoAsync();
        string Description { get; }
    }
}
