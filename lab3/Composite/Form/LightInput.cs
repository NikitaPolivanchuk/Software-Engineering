namespace Composite.Form;

public abstract class LightInput : LightNodeElement
{
    public string Type { get; }
    public object? Value { get; set; }
    public bool Required { get; }
    
    public LightInput(string type, bool required, object? value) 
        : base("input", true, true)
    {
        Type = type;
        Required = required;
        Value = value;
        
        Attributes["type"] = type;
        Attributes["required"] = required ? "true" : "false";
    }

    public abstract bool IsValid();

    protected override void OnBeforeRender()
    {
        Attributes["value"] = Value?.ToString() ?? string.Empty;
    }

    protected override string OnAfterRender(string html)
    {
        return IsValid() 
            ? html 
            : string.Concat(html, "<!-- Not valid -->");
    }
}