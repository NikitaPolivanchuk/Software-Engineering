namespace Composite.NodeElements.Form;

public class LightTextInput : LightInput
{
    public LightTextInput(bool required = false, string? value = null, string placeholder = "") 
        : base("text", required, value, placeholder)
    { }

    public override bool IsValid()
    {
        if (!Required)
        {
            return true;
        }
        return !string.IsNullOrEmpty(Value as string);
    }
}