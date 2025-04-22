namespace Memento;

public class TextEditor
{
    private readonly TextDocument _document = new();
    private readonly Stack<TextDocument.Memento> _history = new();

    public void Write(string text)
    {
        _history.Push(_document.Save());
        _document.Write(text);
    }

    public void Undo()
    {
        if (_history.Count > 0)
        {
            _document.Restore(_history.Pop());
        }
    }

    public void Show()
    {
        Console.WriteLine(_document.Content);
    }
}