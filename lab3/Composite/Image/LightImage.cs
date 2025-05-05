using System.Text;

namespace Composite.Image;

public class LightImage : LightNodeElement
{
    private string _href;
    private IImageLoadStrategy _loadStrategy;

    public string Href
    {
        get => _href;
        set
        {
            _href = value;
            _loadStrategy = value.StartsWith("http")
                ? new NetworkImageLoadStrategy()
                : new FileImageLoadStrategy();
        }
    }
    public string Alt { get; set; } 

    public LightImage(string href, string alt) 
        : base("img", false, true)
    {
        Href = href;
        Alt = alt;
    }


    public override void OnBeforeRender()
    {
        Attributes["href"] = Href;
        Attributes["alt"] = Alt;
    }

    public override void OnAfterRender(StringBuilder htmlBuilder)
    {
        var content = _loadStrategy.Load(Href);
        htmlBuilder.Append($" <!-- {content} -->");
    }
}