using Finance.Models;

namespace Finance.Providers;

public class InMemoryCurrencyProvider : ICurrencyProvider
{
    private readonly Dictionary<Type, Func<int, int, Currency>> _currencies = new();
    
    public T GetCurrency<T>(int intPart, int fractPart)
        where T : Currency
    {
        if (_currencies.TryGetValue(typeof(T), out var factory))
        {
            return (T)factory(intPart, fractPart);
        }
        throw new InvalidOperationException($"Currency of type {typeof(T)} is not registered.");
    }
    
    public void RegisterCurrency<T>(Func<int, int, T> factory)
        where T : Currency
    {
        _currencies[typeof(T)] = factory;
    }
}