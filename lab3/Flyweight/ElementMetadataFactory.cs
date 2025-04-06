namespace Flyweight;

public static class ElementMetadataFactory
{
    private static readonly Dictionary<string, ElementMetadata> Cache = [];

    public static ElementMetadata GetElementMetadata(string tagName, bool isBlock, bool isSelfClosing)
    {
        var key = CreateCacheKey(tagName, isBlock, isSelfClosing);

        if (Cache.TryGetValue(key, out var existingMetadata))
        {
            return existingMetadata;
        }
        
        var metadata = new ElementMetadata(tagName, isBlock, isSelfClosing);
        Cache[key] = metadata;
        return metadata;
    }

    private static string CreateCacheKey(string tagName, bool isBlock, bool isSelfClosing)
    {
        return $"{tagName}:{isBlock}:{isSelfClosing}";
    }
}