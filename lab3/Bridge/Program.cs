using Bridge.Renderers;
using Bridge.Shapes;

namespace Bridge;

internal static class Program
{
    public static void Main(string[] args)
    {
        List<IRenderer> renderers =
        [
            new RasterRenderer(),
            new VectorRenderer(),
        ];

        foreach (var renderer in renderers)
        {
            List<Shape> shapes = [
                new Circle(renderer),
                new Triangle(renderer),
                new Square(renderer),
            ];
            foreach (var shape in shapes)
            {
                shape.Draw();
            }
            Console.WriteLine();
        }
    }
}