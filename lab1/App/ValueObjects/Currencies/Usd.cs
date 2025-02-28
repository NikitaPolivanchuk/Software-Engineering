using Finance;
using Finance.Models;

namespace App.ValueObjects.Currencies;

public class Usd : Currency
{
    public override string Symbol => "$";
    public override int FractionalDigits => 2;
    
    public Usd(int integerPart, int fractionalPart) : base(integerPart, fractionalPart)
    {
    }
}