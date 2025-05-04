using Composite.Iterators;

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
        child.Parent = this;
        children.Add(child);
    }

    public LightNode? Find(
        Predicate<LightNode> predicate,
        TraverseStrategy strategy = TraverseStrategy.BreadthFirst)
    {
        IDomIterator iterator = strategy == TraverseStrategy.BreadthFirst
            ? new BreadthFirstIterator(this)
            : new DepthFirstIterator(this);

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
 
    public abstract string Render();
}