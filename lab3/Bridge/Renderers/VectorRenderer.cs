namespace Bridge.Renderers;

public class VectorRenderer : IRenderer
{
    public void Render(string shapeName)
    {
        Console.WriteLine($"Rendering shape {shapeName} as vector graphics");
    }
}