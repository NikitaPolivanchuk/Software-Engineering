namespace Composite.Visitors;

public class CountVisitor : IDomVisitor
{
    private int _elementCount;
    private int _textNodeCount;

    public CountVisitor()
    {
        _elementCount = 0;
        _textNodeCount = 0;
    }
    
    public void Visit(LightNodeElement element)
    {
        _elementCount++;
        
        foreach (var child in element.Children)
        {
            child.Accept(this);
        }
    }

    public void Visit(LightTextNode textNode)
    {
        _textNodeCount++;
    }
    
    public (int elementCount, int textNodeCount) GetCount()
    {
        return (_elementCount, _textNodeCount);
    }
}