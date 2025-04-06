namespace Flyweight;

public class LightNodeElement : LightNode
{
    private readonly List<LightNode> _children;
    private readonly ElementMetadata _metadata;
    
    public string TagName => _metadata.TagName;
    public bool IsBlock => _metadata.IsBlock;
    public bool IsSelfClosing => _metadata.IsSelfClosing;
    public List<string> ClassList { get; }
    public IReadOnlyList<LightNode> Children => _children;
    
    public LightNodeElement(string tagName, bool isBlock, bool isSelfClosing)
    {
        _metadata = ElementMetadataFactory.GetElementMetadata(tagName, isBlock, isSelfClosing);
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