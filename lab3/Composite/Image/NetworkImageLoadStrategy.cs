namespace Composite.Image;

public class NetworkImageLoadStrategy : IImageLoadStrategy
{
    public string Load(string href)
    {
        return $"[Loaded image from network: {href}]";
    }
}