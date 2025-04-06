using Decorator.Heroes;

namespace Decorator.Items;

public abstract class HeroDecorator : IHero
{
    private readonly IHero _hero;

    protected HeroDecorator(IHero hero)
    {
        _hero = hero;
    }

    public virtual void ShowInfo()
    {
        _hero.ShowInfo();
    }
}