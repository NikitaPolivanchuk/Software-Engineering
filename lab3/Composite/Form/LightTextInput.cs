namespace Composite.Form;

public class LightTextInput : LightInput
{
    public LightTextInput(bool required = false, string? value = null) 
        : base("text", required, value)
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