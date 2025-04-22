using Composite.Image;

namespace Composite;

internal abstract class Program
{
    public static void Main(string[] args)
    {
        var fileImage = new LightImage("images/photo.jpg", "image1");
        var networkImage = new LightImage("http://example.com/photo.jpg", "image2");
        
        Console.WriteLine("File Image Rendered:");
        Console.WriteLine(fileImage.Render());

        Console.WriteLine("\nNetwork Image Rendered:");
        Console.WriteLine(networkImage.Render());
    }
}