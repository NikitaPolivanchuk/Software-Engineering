namespace Composite.NodeElements.Image;

public interface IImageLoadStrategy
{
    string Load(string href);
}