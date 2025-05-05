using System.Text;

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

    public override void OnBeforeRender()
    {
        Attributes["value"] = Value?.ToString() ?? string.Empty;
    }

    public override void OnAfterRender(StringBuilder htmlBuilder)
    {
        if (!IsValid())
        {
            htmlBuilder.Append(" <!-- Not valid -->");
        }
    }
}