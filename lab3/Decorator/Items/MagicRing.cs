using Decorator.Heroes;

namespace Decorator.Items;

public class MagicRing : HeroDecorator
{
    public MagicRing(IHero hero) : base(hero) { }

    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine("Equipped: Magic Ring");
    }
}