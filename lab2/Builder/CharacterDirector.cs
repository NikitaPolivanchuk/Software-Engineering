using System.Drawing;
using Builder.Builders;
using Builder.Domain;

namespace Builder;

public class CharacterDirector
{
    private ICharacterBuilder _builder;

    public CharacterDirector(ICharacterBuilder builder)
    {
        _builder = builder;
    }

    public void SetBuilder(ICharacterBuilder builder)
    {
        _builder = builder;
    }
    
    public Character CreateGoodCharacter()
    {
        return _builder
            .WithName("Arthur")
            .WithHeight(180)
            .WithBuild("Athletic")
            .WithHairColor(Color.SaddleBrown)
            .WithEyeColor(Color.DodgerBlue)
            .WithInventoryItem("Sword")
            .WithInventoryItem("Shield")
            .WithDeed("Kill dragon")
            .Build();
    }

    public Character CreateBadCharacter()
    {
        return _builder
            .WithName("Morgar")
            .WithHeight(175)
            .WithHairColor(Color.Black)
            .WithEyeColor(Color.DarkRed)
            .WithInventoryItem("Dagger")
            .WithDeed("Steal treasures")
            .Build();
    }
}