namespace Memento;

internal abstract class Program
{
    public static void Main(string[] args)
    {
        const string info = "Document content:";
        
        var editor = new TextEditor();

        Console.WriteLine(info);
        editor.Write("line 1\n");
        editor.Show();
        
        Console.WriteLine(info);
        editor.Write("line 2\n");
        editor.Show();
        
        Console.WriteLine(info);
        editor.Undo();
        editor.Show();
        
        Console.WriteLine(info);
        editor.Undo();
        editor.Show();
    }
}