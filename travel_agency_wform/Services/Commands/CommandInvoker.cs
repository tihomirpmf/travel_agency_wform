using System.Collections.Concurrent;

namespace travel_agency_wform.Services.Commands
{
    public class CommandInvoker
    {
        private static readonly Lazy<CommandInvoker> _instance = 
            new Lazy<CommandInvoker>(() => new CommandInvoker());
        
        public static CommandInvoker Instance => _instance.Value;
        
        private readonly Stack<ICommand> _undoStack = new();
        private readonly Stack<ICommand> _redoStack = new();
        private readonly object _lockObject = new();
        
        private CommandInvoker() { }
        
        public async Task<bool> ExecuteCommandAsync(ICommand command)
        {
            if (command == null)
                return false;
            
            try
            {
                var result = await command.ExecuteAsync();
                if (result)
                {
                    lock (_lockObject)
                    {
                        _undoStack.Push(command);
                        _redoStack.Clear(); // Clear redo stack when new command is executed
                    }
                }
                return result;
            }
            catch
            {
                return false;
            }
        }
        
        public async Task<bool> UndoAsync()
        {
            ICommand? command = null;
            lock (_lockObject)
            {
                if (_undoStack.Count > 0)
                {
                    command = _undoStack.Pop();
                }
            }
            if (command == null)
                return false;
            
            try
            {
                var result = await command.UndoAsync();
                if (result)
                {
                    lock (_lockObject)
                    {
                        _redoStack.Push(command);
                    }
                }
                return result;
            }
            catch
            {
                return false;
            }
        }
        
        public async Task<bool> RedoAsync()
        {
            ICommand? command = null;
            lock (_lockObject)
            {
                if (_redoStack.Count > 0)
                {
                    command = _redoStack.Pop();
                }
            }
            if (command == null)
                return false;
            
            try
            {
                var result = await command.ExecuteAsync();
                if (result)
                {
                    lock (_lockObject)
                    {
                        _undoStack.Push(command);
                    }
                }
                return result;
            }
            catch
            {
                return false;
            }
        }
        
        public bool CanUndo => _undoStack.Count > 0;
        public bool CanRedo => _redoStack.Count > 0;
        
        public void ClearHistory()
        {
            lock (_lockObject)
            {
                _undoStack.Clear();
                _redoStack.Clear();
            }
        }
        
        public List<string> GetUndoHistory()
        {
            lock (_lockObject)
            {
                return _undoStack.Select(cmd => cmd.Description).ToList();
            }
        }
        
        public List<string> GetRedoHistory()
        {
            lock (_lockObject)
            {
                return _redoStack.Select(cmd => cmd.Description).ToList();
            }
        }
    }
}
