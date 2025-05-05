using System.Text;

namespace Composite.Visitors;

public class RenderVisitor : IDomVisitor
{
    private readonly StringBuilder _htmlBuilder;
    private int _depth;

    public RenderVisitor()
    {
        _htmlBuilder = new StringBuilder();
        _depth = 0;
    }
    
    public void Visit(LightNodeElement element)
    {
        element.OnBeforeRender();
        
        AppendIndentation();
        _htmlBuilder.Append($"<{element.Name}");

        if (element.ClassList.Count > 0)
        {
            _htmlBuilder.Append($" class=\"{string.Join(' ', element.ClassList)}\"");
        }

        if (element.Attributes.Count > 0)
        {
            foreach (var attribute in element.Attributes)
            {
                _htmlBuilder.Append($" {attribute.Key}=\"{attribute.Value}\"");
            }
        }

        if (element.IsSelfClosing)
        {
            _htmlBuilder.Append(" />");
            element.OnAfterRender(_htmlBuilder);
            _htmlBuilder.AppendLine();
            return;
        }
        
        _htmlBuilder.AppendLine(">");
        _depth++;
        
        foreach (var child in element.Children)
        {
            child.Accept(this);
        }
        
        _depth--;
        AppendIndentation();
        _htmlBuilder.Append($"</{element.Name}>");
        element.OnAfterRender(_htmlBuilder);
        _htmlBuilder.AppendLine();
    }

    public void Visit(LightTextNode textNode)
    {
        AppendIndentation();
        _htmlBuilder.AppendLine(textNode.Text);
    }

    private void AppendIndentation()
    {
        _htmlBuilder.Append(new string(' ', _depth * 2));
    }

    public string GetHtml()
    {
        return _htmlBuilder.ToString();
    }
}