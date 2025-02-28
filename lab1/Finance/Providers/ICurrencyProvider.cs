using Finance.Models;

namespace Finance.Providers;

public interface ICurrencyProvider
{
    T GetCurrency<T>(int intPart, int fractPart)
        where T : Currency;
}