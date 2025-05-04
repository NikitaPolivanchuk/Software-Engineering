namespace Composite;

public class LightTextNode : LightNode
{
    public string Text { get; set; }
    
    public LightTextNode(string text) 
        : base("#text")
    {
        Text = text;
    }

    public override void AppendChild(LightNode child)
    {
        throw new NotSupportedException($"{nameof(LightTextNode)} cannot have children.");
    }

    public override string Render()
    {
        return Text;
    }
}