using System.Text;
using Composite.NodeElements.Form.InputStates;

namespace Composite.NodeElements.Form;

public abstract class LightInput : LightNodeElement
{
    public string Type { get; }
    public object? Value { get; set; }
    public bool Required { get; }
    public string Placeholder { get; }
    public InputState State { get; set; }
    
    public LightInput(string type, bool required, object? value, string placeholder) 
        : base("input", true, true)
    {
        Type = type;
        Required = required;
        Value = value;
        Placeholder = placeholder;
        
        Attributes["type"] = type;
        Attributes["required"] = required ? "true" : "false";

        if (!string.IsNullOrEmpty(placeholder))
        {
            Attributes["placeholder"] = placeholder;
        }

        State = new ActiveState(this);
        State.Blur();
    }

    public abstract bool IsValid();

    public override void OnBeforeRender()
    {
        Attributes["value"] = Value?.ToString() ?? string.Empty;
    }

    public override void OnAfterRender(StringBuilder htmlBuilder)
    {
        htmlBuilder.Append(State.GetMessage());
    }
    
    public void Focus() => State.Focus();
    public void Blur() => State.Blur();
}