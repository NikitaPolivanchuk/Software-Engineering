using Finance.Models;

namespace Finance.Providers;

public interface IRateProvider
{ 
    decimal GetExchangeRate<TFrom, TTo>()
        where TFrom : Currency
        where TTo : Currency;
    
    decimal GetExchangeRate(Type from, Type to);
}