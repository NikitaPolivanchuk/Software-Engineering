using LightNodeL = Flyweight.LightNode;
using LightNodeD = Composite.LightNode;
using LightTextNodeL = Flyweight.LightTextNode;
using LightTextNodeD = Composite.LightTextNode;
using LightNodeElementL = Flyweight.LightNodeElement;
using LightNodeElementD = Composite.LightNodeElement;

namespace Flyweight;

internal abstract class Program
{
    public static void Main(string[] args)
    {
        var memStart = GC.GetTotalMemory(true);
        //1639456 - no sp
        
        //1348392B - default
        //1467688B - no string pool
        var page = CreateBookD();
        
        //1319184 - no sp
        
        //1322504B - default
        //1315976B - no string pool
        //var page = CreateBookL();
        
        var memEnd = GC.GetTotalMemory(true);
        
        //2% reduction - default (generally only booleans)
        //11,5% reduction - no string pool (booleans + strings)
        Console.WriteLine($"Memory usage: {memEnd - memStart}\n");

        page.Render();
    }
    
    
    #region Default

    private static LightNodeD CreateBookD()
    {
        var book = CreateElementD("div");
        using var reader = new StreamReader(@"<path>");
        
        book.AppendChild(CreateElementD("h1", reader.ReadLine() ?? string.Empty));
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            if (line == null)
            {
                continue;
            }
            if (line.Length < 1)
            {
                book.AppendChild(CreateElementD("br"));
            }
            else if (line.StartsWith(' '))
            {
                book.AppendChild(CreateElementD("blockquote", line));
            }
            else if (line.Length < 20)
            {
                book.AppendChild(CreateElementD("h2", line));
            }
            else
            {
                book.AppendChild(CreateElementD("p", line));
            }
        }
        return book;
    }

    private static LightNodeElementD CreateElementD(string tagName, string text)
    {
        var element = CreateElementD(tagName);
        element.AppendChild(new LightTextNodeD(text));
        return element;
    }

    private static LightNodeElementD CreateElementD(string tagName)
    {
        return new LightNodeElementD(tagName, true, false);
    }

    #endregion

    #region Light
    
    private static LightNodeL CreateBookL()
    {
        var book = CreateElementL("div");
        using var reader = new StreamReader(@"<path>");
        
        book.AddChild(CreateElementL("h1", reader.ReadLine() ?? string.Empty));
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
                
            if (string.IsNullOrEmpty(line))
            {
                continue;
            }

            if (line.Length < 1)
            {
                book.AddChild(CreateElementL("br"));
            }
            else if (line.StartsWith(' '))
            {
                book.AddChild(CreateElementL("blockquote", line));
            }
            else if (line.Length <= 20)
            {
                book.AddChild(CreateElementL("h2", line));
            }
            else
            {
                book.AddChild(CreateElementL("p", line));
            }
        }
        return book;
    }

    private static LightNodeElementL CreateElementL(string tagName, string text)
    {
        var element = CreateElementL(tagName);
        element.AddChild(new LightTextNodeL(text));
        return element;
    }

    private static LightNodeElementL CreateElementL(string tagName)
    {
        return new LightNodeElementL(tagName, true, false);
    }

    #endregion
}