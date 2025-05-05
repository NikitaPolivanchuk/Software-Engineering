namespace Composite.NodeElements.Form.InputStates;

public class ActiveState : InputState
{
    public ActiveState(LightInput input) : base(input)
    { }

    public override void Focus() { }

    public override void Blur()
    {
        Input.State = Input.IsValid()
            ? new InactiveState(Input)
            : new InvalidState(Input);
    }

    public override string GetMessage()
    {
        return "<!-- Active -->";
    }
}