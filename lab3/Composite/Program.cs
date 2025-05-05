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

        Console.WriteLine(div.Render());
    }

    private static LightNodeElement CreateElement(string tagName)
    {
        return new LightNodeElement(tagName, true, false);
    }
}