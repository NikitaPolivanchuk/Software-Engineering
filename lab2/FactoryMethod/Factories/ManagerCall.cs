using FactoryMethod.Domain;

namespace FactoryMethod.Factories;

public class ManagerCall : SubscriptionFactory
{
    public override Subscription CreateSubscription()
    {
        return new PremiumSubscription();
    }
}