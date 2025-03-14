namespace FactoryMethod.Domain;

public class PremiumSubscription : Subscription
{
    public override string Name => "Premium Subscription";
    public override decimal MonthlyFee => 400;
    public override int MinimumPeriod => 12;
    public override List<string> Channels => ["Movies", "Sports", "Music"];
    public override List<string> Features => ["Native quality", "No adds", "Offline viewing", "Exclusive content"];
}