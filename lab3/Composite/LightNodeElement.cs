namespace Composite;
using EventHandler = Action<LightNodeElement>;

public class LightNodeElement : LightNode
{
    private readonly List<LightNode> _children;
    private readonly Dictionary<string, List<EventHandler>> _eventListeners;
    
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
        _eventListeners = [];
    }

    public void AddChild(LightNode child)
    {
        if (IsSelfClosing)
        {
            throw new InvalidOperationException("Cannot add child to self closing element");
        }
        child.Parent = this;
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
    
    public void AddEventListener(string eventType, EventHandler handler)
    {
        if (!_eventListeners.ContainsKey(eventType))
        {
            _eventListeners[eventType] = [];
        }
        _eventListeners[eventType].Add(handler);
    }

    public void DispatchEvent(string eventType)
    {
        var current = this;
        while (current != null)
        {
            if (current._eventListeners.TryGetValue(eventType, out var handlers))
            {
                foreach (var handler in handlers)
                {
                    handler(current);
                }
            }
            current = current.Parent as LightNodeElement;
        }
    }
}