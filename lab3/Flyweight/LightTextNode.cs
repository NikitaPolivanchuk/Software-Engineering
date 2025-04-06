namespace Flyweight;

public class LightTextNode : LightNode
{
    public string Text { get; set; }
    
    public LightTextNode(string text)
    {
        Text = text;
    }
    
    public override string Render()
    {
        return Text;
    }
}