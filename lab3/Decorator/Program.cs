using Decorator.Heroes;
using Decorator.Items;

namespace Decorator;

internal abstract class Program
{
    public static void Main(string[] args)
    {
        Dictionary<string, IHero> heroes = new()
        {
            { "Paladin", new Paladin() },
            { "Warrior", new Warrior() },
            { "Mage", new Mage() }
        };
        
        heroes["Paladin"] = new Shield(heroes["Paladin"]);
        
        heroes["Warrior"] = new Sword(heroes["Warrior"]);
        heroes["Warrior"] = new Shield(heroes["Warrior"]);
        
        heroes["Mage"] = new MagicRing(heroes["Mage"]);

        foreach (var hero in heroes.Values)
        {
            hero.ShowInfo();
            Console.WriteLine();
        }
    }
}