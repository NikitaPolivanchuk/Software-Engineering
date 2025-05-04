using Composite.Image;
using Composite.Iterators;

namespace Composite;

internal abstract class Program
{
    public static void Main(string[] args)
    {
        var html = CreateElement("html");
        var body = CreateElement("body");
        var div = CreateElement("div");
        var p1 = CreateElement("p");
        var p2 = CreateElement("p");
        
        html.AppendChild(body);
        body.AppendChild(div);
        div.AppendChild(p1);
        body.AppendChild(p2);
        
        p1.AppendChild(new LightTextNode("This is the first paragraph"));
        p2.AppendChild(new LightTextNode("This is the second paragraph"));

        Console.WriteLine(body.Find(n => n.Name == "p", TraverseStrategy.DepthFirst)?.Render());
        Console.WriteLine(html.Find(n => n.Name == "p")?.Render());
    }

    private static LightNodeElement CreateElement(string tagName)
    {
        return new LightNodeElement(tagName, true, false);
    }
}