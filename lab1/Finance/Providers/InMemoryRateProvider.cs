using Finance.Models;

namespace Finance.Providers;

public class InMemoryRateProvider : IRateProvider
{
    private readonly Dictionary<(Type, Type), decimal> _exchangeRates = new();

    public decimal GetExchangeRate<TFrom, TTo>() where TFrom : Currency where TTo : Currency
    {
        var from = typeof(TFrom);
        var to = typeof(TTo);

        return GetExchangeRate(from, to);
    }

    public decimal GetExchangeRate(Type from, Type to)
    {
        if (_exchangeRates.TryGetValue((from, to), out var rate))
        {
            return rate;
        }
        throw new InvalidOperationException($"Exchange rate from {from.Name} to {to.Name} not set.");
    }


    public void SetExchangeRate<TFrom, TTo>(decimal rate)
        where TFrom : Currency
        where TTo : Currency
    {
        var fromCurrency = typeof(TFrom);
        var toCurrency = typeof(TTo);
        _exchangeRates[(fromCurrency, toCurrency)] = rate;
    }
}