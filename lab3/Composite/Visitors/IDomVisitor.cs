namespace Composite.Visitors;

public interface IDomVisitor
{
    void Visit(LightNodeElement element);
    void Visit(LightTextNode textNode);
}