using Composite.Commands;
using Composite.Iterators;
using Composite.Visitors;

namespace Composite;

public abstract class LightNode
{
    private static readonly CommandManager CommandManager = new();
    
    public string Name { get; }
    public LightNode? Parent { get; set; }
    public List<LightNode> Children { get; }

    public LightNode(string name)
    {
        Name = name;
        Children = [];
    }

    public virtual void AppendChild(LightNode child)
    {
        OnBeforeAppend(child);
        
        CommandManager.Execute(new AppendChildCommand(this, child));
        
        OnAfterAppend(child);
    }

    public LightNode? Find(
        Predicate<LightNode> predicate,
        TraverseStrategy strategy = TraverseStrategy.BreadthFirst)
    {
        var iterator = _getDomIterator(strategy);
        while (iterator.MoveNext())
        {
            var current = iterator.Current;
            if (predicate(current))
            {
                return current;
            }
        }
        return null;
    }

    public List<LightNode> FindAll(
        Predicate<LightNode> predicate,
        TraverseStrategy strategy = TraverseStrategy.BreadthFirst)
    {
        var result = new List<LightNode>();
        
        var iterator = _getDomIterator(strategy);
        while (iterator.MoveNext())
        {
            var current = iterator.Current;
            if (predicate(current))
            {
                result.Add(current);
            }
        }
        return result;
    }
    
    public string Render()
    {
        var visitor = new RenderVisitor();
        Accept(visitor);
        return visitor.GetHtml();
    }

    public string Count()
    {
        var visitor = new CountVisitor();
        Accept(visitor);
        var (elementCount, textCount) = visitor.GetCount();
        return $"Element nodes: {elementCount}\nText nodes: {textCount}";
    }
 
    public abstract void Accept(IDomVisitor visitor);

    private IDomIterator _getDomIterator(TraverseStrategy strategy)
        => strategy switch
        {
            TraverseStrategy.BreadthFirst => new BreadthFirstIterator(this),
            TraverseStrategy.DepthFirst => new DepthFirstIterator(this),
            _ => throw new ArgumentOutOfRangeException(nameof(strategy), strategy, null)
        };
    
    public void Undo() => CommandManager.Undo();
    public void Redo() => CommandManager.Redo();
    
    protected virtual void OnBeforeAppend(LightNode child) { }
    protected virtual void OnAfterAppend(LightNode child) { }
}