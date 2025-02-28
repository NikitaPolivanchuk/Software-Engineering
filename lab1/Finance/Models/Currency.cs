namespace Finance.Models;

public abstract class Currency
{
    public int IntegerPart { get; }
    public int FractionalPart { get; }
    
    public abstract string Symbol { get; }
    public abstract int FractionalDigits { get; }

    protected Currency(int integerPart, int fractionalPart)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(fractionalPart);
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(fractionalPart, Math.Pow(10, FractionalDigits));
        
        IntegerPart = integerPart;
        FractionalPart = fractionalPart;
    }
    
    public decimal ToDecimal()
    {
        var fractionalDecimal = FractionalPart / (decimal)Math.Pow(10, FractionalDigits);
        return IntegerPart + fractionalDecimal;
    }

    public override string ToString()
    {
        return FractionalDigits > 0
            ? $"{Symbol}{IntegerPart},{FractionalPart.ToString().PadLeft(FractionalDigits, '0')}"
            : $"{Symbol}{IntegerPart}";
    }
}