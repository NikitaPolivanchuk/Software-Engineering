namespace Composite.NodeElements.Image;

public class FileImageLoadStrategy : IImageLoadStrategy
{
    public string Load(string href)
    {
        return $"[Loaded image from file system: {href}]";
    }
}