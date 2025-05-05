using Composite.NodeElements.Form;

namespace Composite;

internal abstract class Program
{
    public static void Main(string[] args)
    {
        var div = CreateElement("div");
        
        div.AppendChild(new LightTextInput(true, null, "Enter name"));
        div.AppendChild(new LightTextInput());
        div.AppendChild(new LightNumberInput(placeholder: "Enter age"));
        
        var div2 = CreateElement("div");
        var input = new LightTextInput(true);
        input.Focus();
        div2.AppendChild(input);
        div2.AppendChild(new LightTextNode("some text"));
        div.AppendChild(div2);
        

        Console.WriteLine(div.Render());
        
        div.Undo();
        div.Undo();
        
        Console.WriteLine(div.Render());
        
        div.Redo();
        div.Redo();
        
        Console.WriteLine(div.Render());
    }

    private static LightNodeElement CreateElement(string tagName)
    {
        return new LightNodeElement(tagName, true, false);
    }
}