namespace Composite.Commands;

public class AppendChildCommand : IDomCommand
{
    private readonly LightNode _parent;
    private readonly LightNode _child;

    public AppendChildCommand(LightNode parent, LightNode child)
    {
        _parent = parent;
        _child = child;
    }

    public void Execute()
    {
        _child.Parent = _parent;
        _parent.Children.Add(_child);
    }

    public void Undo()
    {
        _parent.Children.Remove(_child);
        _child.Parent = null;
    }
}