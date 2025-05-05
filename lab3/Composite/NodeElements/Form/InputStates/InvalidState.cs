namespace Composite.NodeElements.Form.InputStates;

public class InvalidState : InputState
{
    public InvalidState(LightInput input) : base(input)
    { }

    public override void Focus()
    {
        Input.State = new ActiveState(Input);
    }

    public override void Blur() { }

    public override string GetMessage()
    {
        return " <!-- Not valid -->";
    }
}