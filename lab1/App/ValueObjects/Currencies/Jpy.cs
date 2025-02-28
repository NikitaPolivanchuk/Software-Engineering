using Finance;
using Finance.Models;

namespace App.ValueObjects.Currencies;

public class Jpy : Currency
{
    public override string Symbol => "¥";
    public override int FractionalDigits => 0;
    
    public Jpy(int integerPart) : base(integerPart, 0)
    {
    }
}