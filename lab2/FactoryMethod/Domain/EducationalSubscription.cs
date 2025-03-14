namespace FactoryMethod.Domain;

public class EducationalSubscription : Subscription
{
    public override string Name => "Educational Subscription";
    public override decimal MonthlyFee => 150;
    public override int MinimumPeriod => 3;
    public override List<string> Channels => ["Sci-fi", "Documentary"];
    public override List<string> Features => ["Access to educational content", "Offline viewing"];
}