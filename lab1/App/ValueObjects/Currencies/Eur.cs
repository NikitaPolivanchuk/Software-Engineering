using Finance;
using Finance.Models;

namespace App.ValueObjects.Currencies;

public class Eur : Currency
{
    public override string Symbol => "€";
    public override int FractionalDigits => 2;


    public Eur(int integerPart, int fractionalPart) : base(integerPart, fractionalPart)
    {
    }
}