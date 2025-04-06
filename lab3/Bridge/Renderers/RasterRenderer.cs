namespace Bridge.Renderers;

public class RasterRenderer : IRenderer 
{
    public void Render(string shapeName)
    {
        Console.WriteLine($"Rendering shape {shapeName} as pixels");
    }
}