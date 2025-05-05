using Composite.Form;

namespace Composite;

internal abstract class Program
{
    public static void Main(string[] args)
    {
        var div = CreateElement("div");
        div.AppendChild(new LightTextInput(true, "some text"));
        div.AppendChild(new LightTextInput());
        div.AppendChild(new LightNumberInput(true));
        
        var div2 = CreateElement("div");
        div2.AppendChild(new LightTextInput());
        div2.AppendChild(new LightTextNode("some text"));
        div.AppendChild(div2);
        

        Console.WriteLine(div.Render());
        Console.WriteLine(div.Count());
    }

    private static LightNodeElement CreateElement(string tagName)
    {
        return new LightNodeElement(tagName, true, false);
    }
}