using App.ValueObjects.Currencies;
using Finance;
using Finance.Providers;
using Finance.Services;
using Microsoft.Extensions.DependencyInjection;

namespace App.DependencyInjection;

public static class CurrencyConfiguration
{
    public static void AddCurrency(this IServiceCollection services)
    {
        services.AddCurrencyRates();
        services.AddCurrencyFactory();
        services.AddSingleton<CurrencyConverter>();
    }
    
    private static void AddCurrencyRates(this IServiceCollection services)
    {
        var rateProvider = new InMemoryRateProvider();
        services.AddSingleton<IRateProvider>(rateProvider);
        
        rateProvider.SetExchangeRate<Usd, Jpy>(150m);
        rateProvider.SetExchangeRate<Jpy, Usd>(0.0067m);
        
        rateProvider.SetExchangeRate<Usd, Eur>(0.96m);
        rateProvider.SetExchangeRate<Eur, Usd>(1.04m);
        
        rateProvider.SetExchangeRate<Usd, Uah>(41.49m);
        rateProvider.SetExchangeRate<Uah, Usd>(0.024m);
    }

    private static void AddCurrencyFactory(this IServiceCollection services)
    {
        var currencyFactory = new InMemoryCurrencyProvider();
        services.AddSingleton<ICurrencyProvider>(currencyFactory);
        
        currencyFactory.RegisterCurrency((i, f) => new Usd(i, f));
        currencyFactory.RegisterCurrency((i, f) => new Eur(i, f));
        currencyFactory.RegisterCurrency((i, f) => new Uah(i, f));
        currencyFactory.RegisterCurrency((i, _) => new Jpy(i));
    }
}