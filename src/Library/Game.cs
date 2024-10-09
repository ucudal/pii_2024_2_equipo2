using Library.FamilyType;
using Library.Interfaces;

namespace Library;
using Library;

public class Game
{
    public void Main()
    {
        GrassType Grass = new GrassType();
        FireType Fire = new FireType();
        NormalType Normal = new NormalType();
        WaterType Water = new WaterType();

        Attack Ember = new Attack("Ember", 50, Fire);
        Attack Scratch = new Attack("Scratch", 30, Normal);
        Attack Flamethrower = new Attack("Flamethrower", 90, Fire);
        Attack FireFang = new Attack("FireFang", 65, Fire);

        Attack WaterGun = new Attack("WaterGun", 40, Water);
        Attack Tackle = new Attack("Tackle", 50, Normal);
        Attack Bubble = new Attack("Bubble", 20, Water);
        Attack AquaJet = new Attack("AquaJet", 60, Water);

        Attack VineWhip = new Attack("VineWhip", 45, Grass);
        Attack SolarBeam = new Attack("SolarBeam", 100, Grass);
        Attack LeechSeed = new Attack("LeachSeed", 0, Grass);

        Pokemon Bulbasaur = new Pokemon(200, Grass, new List<Attack> { VineWhip, Tackle, SolarBeam, LeechSeed }, 30);
        Pokemon Squirtle = new Pokemon(200, Water, new List<Attack> { WaterGun, Tackle, Bubble, AquaJet }, 25);
        Pokemon Charmander = new Pokemon(200, Fire, new List<Attack> { Ember, Scratch, Flamethrower, FireFang }, 30);
        
    }

    public bool AllPokemonDead(Player player)
    {
        int AliveCount = player.Pokemons.Count();
        foreach (var pokemon in player.Pokemons)
        {
            if (pokemon.Life <= 0)
            {
                AliveCount -= 1;
            }
        }

        if (AliveCount > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}