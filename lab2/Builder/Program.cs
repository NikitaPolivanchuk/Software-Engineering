using Builder.Domain;

namespace Builder;

internal abstract class Program
{
    public static void Main(string[] args)
    {
        var director = new CharacterDirector(Hero.CreateBuilder());
        var hero = (Hero)director.CreateGoodCharacter();
        hero.MakeGoodDeed();
        hero.DisplayInfo();

        Console.WriteLine();
        
        director.SetBuilder(Enemy.CreateBuilder());
        var enemy = (Enemy)director.CreateBadCharacter();
        enemy.MakeBadDeed();
        enemy.DisplayInfo();
    }
}