## SOLID Principles:

### Single Responsibility Principle:

Each class has a single responsibility:
- [`Product`](https://github.com/NikitaPolivanchuk/Software-Engineering/blob/162d2f3db82434681d8ea3e2287d51061a84fb5c/lab1/App/Entities/Product.cs), [`Category`](https://github.com/NikitaPolivanchuk/Software-Engineering/blob/162d2f3db82434681d8ea3e2287d51061a84fb5c/lab1/App/Entities/Category.cs), [`Warehouse`](https://github.com/NikitaPolivanchuk/Software-Engineering/blob/162d2f3db82434681d8ea3e2287d51061a84fb5c/lab1/App/Entities/Warehouse.cs), and [`Address`](https://github.com/NikitaPolivanchuk/Software-Engineering/blob/162d2f3db82434681d8ea3e2287d51061a84fb5c/lab1/App/ValueObjects/Address.cs) are pure data models.
- [`WarehouseReportService`](https://github.com/NikitaPolivanchuk/Software-Engineering/blob/162d2f3db82434681d8ea3e2287d51061a84fb5c/lab1/App/Services/WarehouseReportService.cs) handles report generation.
- [`CurrencyConverter`](https://github.com/NikitaPolivanchuk/Software-Engineering/blob/162d2f3db82434681d8ea3e2287d51061a84fb5c/lab1/Finance/Services/CurrencyConverter.cs) focuses on currency conversion.
- [`InMemoryRateProvider`](https://github.com/NikitaPolivanchuk/Software-Engineering/blob/162d2f3db82434681d8ea3e2287d51061a84fb5c/lab1/Finance/Providers/InMemoryRateProvider.cs) and [`InMemoryCurrencyProvider`](https://github.com/NikitaPolivanchuk/Software-Engineering/blob/162d2f3db82434681d8ea3e2287d51061a84fb5c/lab1/Finance/Providers/InMemoryCurrencyProvider.cs) manage exchange rates and currency creation.

### Open/Closed Principle:

- [`Currency`](https://github.com/NikitaPolivanchuk/Software-Engineering/blob/162d2f3db82434681d8ea3e2287d51061a84fb5c/lab1/Finance/Models/Currency.cs) class is open for extension (new currency [types](https://github.com/NikitaPolivanchuk/Software-Engineering/tree/main/lab1/App/ValueObjects/Currencies) like [`Usd`](https://github.com/NikitaPolivanchuk/Software-Engineering/blob/162d2f3db82434681d8ea3e2287d51061a84fb5c/lab1/App/ValueObjects/Currencies/Usd.cs), [`Eur`](https://github.com/NikitaPolivanchuk/Software-Engineering/blob/162d2f3db82434681d8ea3e2287d51061a84fb5c/lab1/App/ValueObjects/Currencies/Eur.cs), etc.) but closed for modification.
- [`IRateProvider`](https://github.com/NikitaPolivanchuk/Software-Engineering/blob/162d2f3db82434681d8ea3e2287d51061a84fb5c/lab1/Finance/Providers/IRateProvider.cs) and [`ICurrencyProvider`](https://github.com/NikitaPolivanchuk/Software-Engineering/blob/162d2f3db82434681d8ea3e2287d51061a84fb5c/lab1/Finance/Providers/ICurrencyProvider.cs) allow new implementations without modifying existing code.

### Liskov Substitution Principle:

- Subtypes like [`Usd`](https://github.com/NikitaPolivanchuk/Software-Engineering/blob/162d2f3db82434681d8ea3e2287d51061a84fb5c/lab1/App/ValueObjects/Currencies/Usd.cs), [`Eur`](https://github.com/NikitaPolivanchuk/Software-Engineering/blob/162d2f3db82434681d8ea3e2287d51061a84fb5c/lab1/App/ValueObjects/Currencies/Eur.cs), [`Jpy`](https://github.com/NikitaPolivanchuk/Software-Engineering/blob/162d2f3db82434681d8ea3e2287d51061a84fb5c/lab1/App/ValueObjects/Currencies/Jpy.cs), and [`Uah`](https://github.com/NikitaPolivanchuk/Software-Engineering/blob/162d2f3db82434681d8ea3e2287d51061a84fb5c/lab1/App/ValueObjects/Currencies/Uah.cs) can replace the base [`Currency`](https://github.com/NikitaPolivanchuk/Software-Engineering/blob/162d2f3db82434681d8ea3e2287d51061a84fb5c/lab1/Finance/Models/Currency.cs) class without breaking functionality.

### Interface Segregation Principle:

- Interfaces like [`IRateProvider`](https://github.com/NikitaPolivanchuk/Software-Engineering/blob/162d2f3db82434681d8ea3e2287d51061a84fb5c/lab1/Finance/Providers/IRateProvider.cs), [`ICurrencyProvider`](https://github.com/NikitaPolivanchuk/Software-Engineering/blob/162d2f3db82434681d8ea3e2287d51061a84fb5c/lab1/Finance/Providers/ICurrencyProvider.cs), and [`IWarehouseProvider`](https://github.com/NikitaPolivanchuk/Software-Engineering/blob/162d2f3db82434681d8ea3e2287d51061a84fb5c/lab1/App/Providers/IWarehouseProvider.cs) keep contracts small and focused.

### Dependency Inversion Principle:

- High-level modules (e.g., [`WarehouseReportService`](https://github.com/NikitaPolivanchuk/Software-Engineering/blob/162d2f3db82434681d8ea3e2287d51061a84fb5c/lab1/App/Services/WarehouseReportService.cs#L11)) depend on abstractions ([`IWarehouseProvider`](https://github.com/NikitaPolivanchuk/Software-Engineering/blob/162d2f3db82434681d8ea3e2287d51061a84fb5c/lab1/App/Providers/IWarehouseProvider.cs), [`IRateProvider`](https://github.com/NikitaPolivanchuk/Software-Engineering/blob/162d2f3db82434681d8ea3e2287d51061a84fb5c/lab1/Finance/Providers/IRateProvider.cs)) rather than concrete implementations.

## DRY Principle:

Common operations are encapsulated:
- [`CurrencyConfiguration`](https://github.com/NikitaPolivanchuk/Software-Engineering/blob/main/lab1/App/DependencyInjection/CurrencyConfiguration.cs) centralizes service registrations.
- [`CurrencyConverter.Convert`](https://github.com/NikitaPolivanchuk/Software-Engineering/blob/162d2f3db82434681d8ea3e2287d51061a84fb5c/lab1/Finance/Services/CurrencyConverter.cs#L17) handles conversion logic in one place.
- Repeated report sections are handled by helper methods ([`AppendWarehouseDetails`](https://github.com/NikitaPolivanchuk/Software-Engineering/blob/162d2f3db82434681d8ea3e2287d51061a84fb5c/lab1/App/Services/WarehouseReportService.cs#L47), [`AppendGrandTotal`](https://github.com/NikitaPolivanchuk/Software-Engineering/blob/162d2f3db82434681d8ea3e2287d51061a84fb5c/lab1/App/Services/WarehouseReportService.cs#L75)).

## KISS Principle:

Code is straightforward:
- Clear domain models (e.g., [`Product`](https://github.com/NikitaPolivanchuk/Software-Engineering/blob/162d2f3db82434681d8ea3e2287d51061a84fb5c/lab1/App/Entities/Product.cs#L5), [`Warehouse`](https://github.com/NikitaPolivanchuk/Software-Engineering/blob/main/lab1/App/Entities/Warehouse.cs)).
- Simple data structures like dictionaries ([`_exchangeRates`](https://github.com/NikitaPolivanchuk/Software-Engineering/blob/162d2f3db82434681d8ea3e2287d51061a84fb5c/lab1/Finance/Providers/InMemoryRateProvider.cs#L7), [`_currencies`](https://github.com/NikitaPolivanchuk/Software-Engineering/blob/162d2f3db82434681d8ea3e2287d51061a84fb5c/lab1/Finance/Providers/InMemoryCurrencyProvider.cs#L7)).

## Composition Over Inheritance:

Composition is preferred where appropriate:
- Warehouse contains a list of [`Product`](https://github.com/NikitaPolivanchuk/Software-Engineering/blob/162d2f3db82434681d8ea3e2287d51061a84fb5c/lab1/App/Entities/Product.cs#L5) instances.
- [`CurrencyConverter`](https://github.com/NikitaPolivanchuk/Software-Engineering/blob/main/lab1/Finance/Services/CurrencyConverter.cs) uses [`IRateProvider`](https://github.com/NikitaPolivanchuk/Software-Engineering/blob/162d2f3db82434681d8ea3e2287d51061a84fb5c/lab1/Finance/Services/CurrencyConverter.cs#L8) and [`ICurrencyProvider`](https://github.com/NikitaPolivanchuk/Software-Engineering/blob/162d2f3db82434681d8ea3e2287d51061a84fb5c/lab1/Finance/Services/CurrencyConverter.cs#L9) via dependency injection.

## Program to Interfaces, Not Implementations:

Interfaces drive the architecture:
- [`IWarehouseProvider`](https://github.com/NikitaPolivanchuk/Software-Engineering/blob/162d2f3db82434681d8ea3e2287d51061a84fb5c/lab1/App/Providers/IWarehouseProvider.cs#L5), [`IRateProvider`](https://github.com/NikitaPolivanchuk/Software-Engineering/blob/162d2f3db82434681d8ea3e2287d51061a84fb5c/lab1/Finance/Providers/IRateProvider.cs#L5), [`ICurrencyProvider`](https://github.com/NikitaPolivanchuk/Software-Engineering/blob/162d2f3db82434681d8ea3e2287d51061a84fb5c/lab1/Finance/Providers/ICurrencyProvider.cs#L5) define behavior.
- Concrete implementations are injected.

## Fail Fast Principle:

Immediate failure on invalid state:
- [`Currency`](https://github.com/NikitaPolivanchuk/Software-Engineering/blob/162d2f3db82434681d8ea3e2287d51061a84fb5c/lab1/Finance/Models/Currency.cs#L13) constructor validates fractional part with `ArgumentOutOfRangeException`.
- [`InMemoryRateProvider.GetExchangeRate`](https://github.com/NikitaPolivanchuk/Software-Engineering/blob/162d2f3db82434681d8ea3e2287d51061a84fb5c/lab1/Finance/Providers/InMemoryRateProvider.cs#L23) throws an exception for missing rates.

