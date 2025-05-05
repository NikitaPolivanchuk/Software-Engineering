namespace Composite.Commands;

public interface IDomCommand
{
    void Execute();
    void Undo();
}