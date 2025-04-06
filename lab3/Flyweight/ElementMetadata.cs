namespace Flyweight;

public record ElementMetadata
{
    public string TagName { get; }
    public bool IsBlock { get; }
    public bool IsSelfClosing { get; }
    
    public ElementMetadata(string tagName, bool isBlock, bool isSelfClosing)
    {
        TagName = tagName;
        IsBlock = isBlock;
        IsSelfClosing = isSelfClosing;
    }
}