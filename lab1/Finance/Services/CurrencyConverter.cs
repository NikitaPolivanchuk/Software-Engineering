using Finance.Models;
using Finance.Providers;

namespace Finance.Services;

public class CurrencyConverter
{
    private readonly IRateProvider _rateProvider;
    private readonly ICurrencyProvider _currencyProvider;

    public CurrencyConverter(IRateProvider rateProvider, ICurrencyProvider currencyProvider)
    {
        _rateProvider = rateProvider;
        _currencyProvider = currencyProvider;
    }

    public TTo Convert<TTo>(Currency amount)
        where TTo : Currency
    {
        if (amount.GetType() == typeof(TTo))
        {
            return (TTo)amount;
        }
        
        var rate = _rateProvider.GetExchangeRate(amount.GetType(), typeof(TTo));
        var totalAmount = amount.IntegerPart + amount.FractionalPart / (decimal)Math.Pow(10, amount.FractionalDigits);
        var convertedAmount = totalAmount * rate;

        var toCurrency = _currencyProvider.GetCurrency<TTo>(0, 0);
        
        var newIntegerPart = (int)convertedAmount;
        var newFractionalPart = (int)((convertedAmount - newIntegerPart) * (decimal)Math.Pow(10, toCurrency.FractionalDigits));

        return _currencyProvider.GetCurrency<TTo>(newIntegerPart, newFractionalPart);
    }
}