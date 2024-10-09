using Library;
using Library.FamilyType;
using Library.Interfaces;
public class Program
{
    public static void Main()
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

        //Charmander.ReceiveAttack(Bulbasaur.Attacks[2]);
        //Console.WriteLine("Bulbasaur ataca a Charmander con SolarBeam (100 de daño) pero es poco efectivo por lo que hace 50 de daño, vida de Charmander: " + Charmander.Life);
        
        //Bulbasaur.ReceiveAttack(Charmander.Attacks[2]);
        //Console.WriteLine("Charmander ataca a Bulbasaur con Flamethrower (90 de daño) y es muy efectivo por lo que hace 180 de daño, vida de Bulbasaur: " + Bulbasaur.Life);
        
        Player Player1 = new Player("player1");
        Player Player2 = new Player("player2");
        
        Player1.AddPokemon(Bulbasaur);
        Player1.AddPokemon(Squirtle);
        
        Player2.AddPokemon(Charmander);
        Player2.AddPokemon(Squirtle);
        
        Player1.Pokemons[1].ReceiveAttack(Player2.Pokemons[0].Attacks[2], Player2.Pokemons[0].PType);
        Console.WriteLine(Player1.Pokemons[1].Life);
        Console.WriteLine(Player2.Pokemons[1].Life);

    }
}

// prueba de branch - ...

