using System.Drawing;
using Builder.Domain;

namespace Builder.Builders;

public class EnemyBuilder : ICharacterBuilder
{
    private readonly Enemy _enemy;

    public EnemyBuilder(Enemy enemy)
    {
        _enemy = enemy;
    }

    public ICharacterBuilder WithName(string name)
    {
        _enemy.Name = name;
        return this;
    }

    public ICharacterBuilder WithHeight(double height)
    {
        _enemy.Height = height;
        return this;
    }

    public ICharacterBuilder WithBuild(string build)
    {
        _enemy.Build = build;
        return this;
    }

    public ICharacterBuilder WithHairColor(Color hairColor)
    {
        _enemy.HairColor = hairColor;
        return this;
    }

    public ICharacterBuilder WithEyeColor(Color eyeColor)
    {
        _enemy.EyeColor = eyeColor;
        return this;
    }

    public ICharacterBuilder WithInventoryItem(string item)
    {
        _enemy.Inventory.Add(item);
        return this;
    }

    public ICharacterBuilder WithDeed(string deed)
    {
        _enemy.BadDeeds.Add(deed);
        return this;
    }

    public Character Build()
    {
        return _enemy;
    }
}