using Composite.Iterators;
using Composite.Visitors;

namespace Composite;

public abstract class LightNode
{
    protected List<LightNode> children;
    
    public string Name { get; }
    public LightNode? Parent { get; set; }
    public IReadOnlyList<LightNode> Children => children;

    public LightNode(string name)
    {
        Name = name;
        children = [];
    }

    public virtual void AppendChild(LightNode child)
    {
        OnBeforeAppend(child);
        
        child.Parent = this;
        children.Add(child);
        
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
    
    protected virtual void OnBeforeAppend(LightNode child) { }
    protected virtual void OnAfterAppend(LightNode child) { }
}