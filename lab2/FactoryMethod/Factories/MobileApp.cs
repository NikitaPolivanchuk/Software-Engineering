using FactoryMethod.Domain;

namespace FactoryMethod.Factories;

public class MobileApp : SubscriptionFactory
{
    public override Subscription CreateSubscription()
    {
        return new EducationalSubscription();
    }
}