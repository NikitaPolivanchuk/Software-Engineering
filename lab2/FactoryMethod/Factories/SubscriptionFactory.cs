using FactoryMethod.Domain;

namespace FactoryMethod.Factories;

public abstract class SubscriptionFactory
{
    public abstract Subscription CreateSubscription();
}