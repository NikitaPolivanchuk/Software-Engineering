namespace Composite.Image;

public interface IImageLoadStrategy
{
    string Load(string href);
}