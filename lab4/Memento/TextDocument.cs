using System.Text;

namespace Memento;

public class TextDocument
{
    public string Content { get; private set; } = string.Empty;

    public void Write(string text)
    {
        Content += text;
    }

    public Memento Save()
    {
        return new Memento(Content);
    }

    public void Restore(Memento memento)
    {
        Content = memento.Content;
    }

    public class Memento
    {
        internal string Content { get; }

        internal Memento(string content)
        {
            Content = content;
        }
    }
}