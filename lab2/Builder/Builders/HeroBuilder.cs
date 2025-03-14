using System.Drawing;
using Builder.Domain;

namespace Builder.Builders;

public class HeroBuilder : ICharacterBuilder
{
    private readonly Hero _hero;

    public HeroBuilder(Hero hero)
    {
        _hero = hero;
    }

    public ICharacterBuilder WithName(string name)
    {
        _hero.Name = name;
        return this;
    }

    public ICharacterBuilder WithHeight(double height)
    {
        _hero.Height = height;
        return this;
    }

    public ICharacterBuilder WithBuild(string build)
    {
        _hero.Build = build;
        return this;
    }

    public ICharacterBuilder WithHairColor(Color hairColor)
    {
        _hero.HairColor = hairColor;
        return this;
    }

    public ICharacterBuilder WithEyeColor(Color eyeColor)
    {
        _hero.EyeColor = eyeColor;
        return this;
    }

    public ICharacterBuilder WithInventoryItem(string itemName)
    {
        _hero.Inventory.Add(itemName);
        return this;
    }

    public ICharacterBuilder WithDeed(string deed)
    {
        _hero.GoodDeeds.Add(deed);
        return this;
    }

    public Character Build()
    {
        return _hero;
    }
}