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

    public override string Render()
    {
        var classAttribute = ClassList.Count > 0
            ? $" class=\"{string.Join(' ', ClassList)}\""
            : string.Empty;
        
        var content = _loadStrategy.Load(Href);
        
        return $"<img src=\"{_href}\" alt=\"{Alt}\"{classAttribute} /> <!-- {content} -->";
    }
}