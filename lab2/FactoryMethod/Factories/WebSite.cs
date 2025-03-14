using FactoryMethod.Domain;

namespace FactoryMethod.Factories;

public class WebSite : SubscriptionFactory
{
    public override Subscription CreateSubscription()
    {
        return new DomesticSubscription();
    }
}