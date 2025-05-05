namespace Composite.NodeElements.Form;

public class LightNumberInput : LightInput
{
    public LightNumberInput(bool required = false, int? value = null, string placeholder = "") 
        : base("number", required, value, placeholder)
    { }

    public override bool IsValid()
    {
        if (!Required)
        {
            return true;
        }
        return Value is not null;
    }
}