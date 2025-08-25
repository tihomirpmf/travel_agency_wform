namespace travel_agency_wform.Services.Commands
{
    public interface ICommand
    {
        Task<bool> ExecuteAsync();
        Task<bool> UndoAsync();
        string Description { get; }
    }
}
