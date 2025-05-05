namespace Composite.NodeElements.Form.InputStates;

public class InactiveState : InputState
{
    public InactiveState(LightInput input) : base(input)
    { }

    public override void Focus()
    {
        Input.State = new ActiveState(Input);
    }

    public override void Blur() { }

    public override string GetMessage()
    {
        return Input.Value == null && !string.IsNullOrEmpty(Input.Placeholder)
            ? $"<!-- {Input.Placeholder} -->"
            : string.Empty;
    }
}