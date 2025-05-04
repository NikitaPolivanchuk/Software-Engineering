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
 
    public abstract string Render();
}