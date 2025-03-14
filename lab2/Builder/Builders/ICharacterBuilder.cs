using System.Drawing;
using Builder.Domain;

namespace Builder.Builders;

public interface ICharacterBuilder
{
    ICharacterBuilder WithName(string name);
    ICharacterBuilder WithHeight(double height);
    ICharacterBuilder WithBuild(string build);
    ICharacterBuilder WithHairColor(Color hairColor);
    ICharacterBuilder WithEyeColor(Color eyeColor);
    ICharacterBuilder WithInventoryItem(string item);
    ICharacterBuilder WithDeed(string deed);
    Character Build();
}