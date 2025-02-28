using Finance;
using Finance.Models;

namespace App.ValueObjects.Currencies;

public class Uah : Currency
{
    public override string Symbol => "₴";
    public override int FractionalDigits => 2;

    
    public Uah(int integerPart, int fractionalPart) : base(integerPart, fractionalPart)
    {
    }
}