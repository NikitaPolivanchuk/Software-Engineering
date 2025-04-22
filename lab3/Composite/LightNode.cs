namespace Composite;

public abstract class LightNode
{
    public LightNode? Parent { get; set; }
    public abstract string Render();
}