namespace Composite.NodeElements.Form.InputStates;

public abstract class InputState
{
    protected LightInput Input;

    public InputState(LightInput input)
    {
        Input = input;
    }

    public abstract void Focus();
    public abstract void Blur();

    public abstract string GetMessage();
}