using System.Text;

namespace FactoryMethod.Domain;

public abstract class Subscription
{
    public abstract string Name { get; }
    public abstract decimal MonthlyFee { get; }
    public abstract int MinimumPeriod { get; }
    public abstract List<string> Channels { get; }
    public abstract List<string> Features { get; }

    public override string ToString()
    {
        var str = new StringBuilder();
        str.AppendLine($"Name: {Name}");
        str.AppendLine($"Monthly Fee: {MonthlyFee}");
        str.AppendLine($"Minimum Period: {MinimumPeriod}");
        str.AppendLine($"Channels: {string.Join(", ", Channels)}");
        str.AppendLine($"Features: {string.Join(", ", Features)}");
        
        return str.ToString();
    }
}