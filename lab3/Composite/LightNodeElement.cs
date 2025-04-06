namespace Composite;

public class LightNodeElement : LightNode
{
    private readonly List<LightNode> _children;
    
    public string TagName { get; }
    public bool IsBlock { get; }
    public bool IsSelfClosing { get; }
    public List<string> ClassList { get; }
    public IReadOnlyList<LightNode> Children => _children;
    
    public LightNodeElement(string tagName, bool isBlock, bool isSelfClosing)
    {
        TagName = tagName;
        IsBlock = isBlock;
        IsSelfClosing = isSelfClosing;
        ClassList = [];
        _children = [];
    }

    public void AddChild(LightNode child)
    {
        if (IsSelfClosing)
        {
            throw new InvalidOperationException("Cannot add child to self closing element");
        }
        _children.Add(child);
    }

    public string InnerHtml => string.Join(string.Empty, Children.Select(node => node.Render()));

    public string OuterHtml => Render();
    
    public override string Render()
    {
        var classAttribute = ClassList.Count > 0 
            ? $" class=\"{string.Join(' ', ClassList)}\"" 
            : string.Empty;
        
        return IsSelfClosing
            ? $"<{TagName}{classAttribute}> />"
            : $"<{TagName}{classAttribute}>{InnerHtml}</{TagName}>";
    }
}