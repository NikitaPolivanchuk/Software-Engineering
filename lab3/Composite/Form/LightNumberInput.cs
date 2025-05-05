namespace Composite.Form;

public class LightNumberInput : LightInput
{
    public LightNumberInput(bool required = false, int? value = null) 
        : base("number", required, value)
    { }

    public override bool IsValid()
    {
        return Required && Value is not null;
    }
}