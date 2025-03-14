namespace FactoryMethod.Domain;

public class DomesticSubscription : Subscription
{
    public override string Name => "Domestic Subscription";
    public override decimal MonthlyFee => 200;
    public override int MinimumPeriod => 6;
    public override List<string> Channels => ["News", "Movies", "Sports"];
    public override List<string> Features => ["HD quality"];
}