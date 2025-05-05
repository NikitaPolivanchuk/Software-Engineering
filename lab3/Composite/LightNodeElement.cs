namespace Composite;
using EventHandler = Action<LightNodeElement>;

public class LightNodeElement : LightNode
{
    protected readonly Dictionary<string, string> Attributes;
    protected readonly Dictionary<string, List<EventHandler>> EventListeners;
    
    public string TagName { get; }
    public bool IsBlock { get; }
    public bool IsSelfClosing { get; }
    public List<string> ClassList { get; }
    
    public LightNodeElement(string tagName, bool isBlock, bool isSelfClosing) 
        : base(tagName)
    {
        TagName = tagName;
        IsBlock = isBlock;
        IsSelfClosing = isSelfClosing;
        ClassList = [];
        Attributes = [];
        EventListeners = [];
    }

    public override void AppendChild(LightNode child)
    {
        if (IsSelfClosing)
        {
            throw new NotSupportedException("Cannot add child to self closing element.");
        }
        base.AppendChild(child);
    }

    public string InnerHtml => string.Join(string.Empty, Children.Select(node => node.Render()));

    public string OuterHtml => Render();
    
    public override string Render()
    {
        OnBeforeRender();
        
        if (ClassList.Count > 0)
        {
            Attributes["class"] = string.Join(' ', ClassList);
        }

        var attributes = string.Join(" ", Attributes.Select(kvp => $"{kvp.Key}=\"{kvp.Value}\""));
        var attributesWithSpace = string.IsNullOrEmpty(attributes) ? "" : " " + attributes;
        
        var html = IsSelfClosing
            ? $"<{TagName}{attributesWithSpace} />"
            : $"<{TagName}{attributesWithSpace}>{InnerHtml}</{TagName}>";
        
        return OnAfterRender(html);
    }
    
    public void AddEventListener(string eventType, EventHandler handler)
    {
        if (!EventListeners.ContainsKey(eventType))
        {
            EventListeners[eventType] = [];
        }
        EventListeners[eventType].Add(handler);
    }

    public void DispatchEvent(string eventType)
    {
        var current = this;
        while (current != null)
        {
            if (current.EventListeners.TryGetValue(eventType, out var handlers))
            {
                foreach (var handler in handlers)
                {
                    handler(current);
                }
            }
            current = current.Parent as LightNodeElement;
        }
    }

    protected virtual void OnBeforeRender() { }
    protected virtual string OnAfterRender(string html) => html;
}