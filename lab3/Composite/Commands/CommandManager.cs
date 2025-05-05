namespace Composite.Commands;

public class CommandManager
{
    private readonly Stack<IDomCommand> _undoStack = [];
    private readonly Stack<IDomCommand> _redoStack = [];

    public void Execute(IDomCommand command)
    {
        command.Execute();
        _undoStack.Push(command);
        _redoStack.Clear();
    }

    public void Undo()
    {
        if (_undoStack.Count == 0)
        {
            return;
        }

        var command = _undoStack.Pop();
        command.Undo();
        _redoStack.Push(command);
    }

    public void Redo()
    {
        if (_redoStack.Count == 0)
        {
            return;
        }
        
        var command = _redoStack.Pop();
        command.Execute();
        _undoStack.Push(command);
    }
}