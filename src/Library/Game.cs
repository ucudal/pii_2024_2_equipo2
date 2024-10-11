using Library.FamilyType;

namespace Library;

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
        Attack LeechSeed = new Attack("LeachSeed", 10, Grass);
        Attack RazorLeaf = new Attack("RazorLeaf", 55, Grass);
        Attack LeafBlade = new Attack("LeafBlade", 70, Grass);
        Attack FireBlast = new Attack("FireBlast", 110, Fire);
        Attack FlameCharge = new Attack("FlameCharge", 50, Fire);
        Attack HydroPump = new Attack("HydroPump", 110, Water);
        Attack Surf = new Attack("Surf", 90, Water);
        Attack BodySlam = new Attack("BodySlam", 85, Normal);
        Attack QuickAttack = new Attack("QuickAttack", 40, Normal);
        Attack HyperBeam = new Attack("HyperBeam", 120, Normal);
        Attack Bite = new Attack("Bite", 60, Normal);
        
        Pokemon Bulbasaur = new Pokemon("Bulbasaur", 200, Grass, new List<Attack> { VineWhip, Tackle, SolarBeam, RazorLeaf }, 50);
        Pokemon Squirtle = new Pokemon("Squirtle", 200, Water, new List<Attack> { WaterGun, Tackle, Bubble, AquaJet }, 25);
        Pokemon Charmander = new Pokemon("Charmander", 200, Fire, new List<Attack> { Ember, Scratch, Flamethrower, FireFang }, 30);
        Pokemon Ivysaur = new Pokemon("Ivysaur", 250, Grass, new List<Attack> { VineWhip, SolarBeam, RazorLeaf, LeafBlade }, 35);
        Pokemon Wartortle = new Pokemon("Wartortle", 250, Water, new List<Attack> { WaterGun, AquaJet, Surf, Bite }, 30);
        Pokemon Charmeleon = new Pokemon("Charmeleon", 250, Fire, new List<Attack> { Ember, FireFang, Flamethrower, FlameCharge }, 35);
        Pokemon Venusaur = new Pokemon("Venusaur", 300, Grass, new List<Attack> { VineWhip, SolarBeam, LeafBlade, LeechSeed }, 40);
        Pokemon Blastoise = new Pokemon("Blastoise", 300, Water, new List<Attack> { WaterGun, AquaJet, HydroPump, Surf }, 40);
        Pokemon Charizard = new Pokemon("Charizard", 300, Fire, new List<Attack> { Ember, Flamethrower, FireBlast, Scratch }, 40);
        Pokemon Oddish = new Pokemon("Oddish", 180, Grass, new List<Attack> { VineWhip, RazorLeaf, LeechSeed, Tackle }, 20);
        Pokemon Vaporeon = new Pokemon("Vaporeon", 270, Water, new List<Attack> { WaterGun, AquaJet, Bubble, Surf }, 35);
        Pokemon Flareon = new Pokemon("Flareon", 270, Fire, new List<Attack> { Ember, FireBlast, FlameCharge, Bite }, 35);
        Pokemon Eevee = new Pokemon("Eevee", 200, Normal, new List<Attack> { Scratch, Tackle, QuickAttack, HyperBeam }, 25);
        Pokemon Bellsprout = new Pokemon("Bellsprout", 190, Grass, new List<Attack> { VineWhip, RazorLeaf, LeechSeed, LeafBlade }, 22);
        Pokemon Growlithe = new Pokemon("Growlithe", 220, Fire, new List<Attack> { Ember, FireFang, FlameCharge, Bite }, 30);

        
        Player Player1 = new Player("player1");
        Player Player2 = new Player("player2");
    }

    public static void WhoStarts(Player player1, Player player2)
    {
        double speed1 = player1.PokemonInGame[0].Speed;
        double speed2 = player2.PokemonInGame[0].Speed;

        if (speed1 > speed2)
        {
            player1.Turn = true;
        }
        else
        {
            player2.Turn = true;
        }
    }

    public static void ChangeTurn(Player player1, Player player2)
    {
        if (player1.Turn == true)
        {
            player1.Turn = false;
            player2.Turn = true;
        }
        else
        {
            player1.Turn = true;
            player2.Turn = false; 
        }
    }

    public static void UseTurn(Player player1, Player player2)
    {
        Random rnd = new Random();
        int num = rnd.Next(3);
        
        if (player1.Turn)
        {
            player2.PokemonInGame[0].ReceiveAttack(player1.PokemonInGame[0].Attacks[num]);
            bool stopPlaying = AllPokemonDead(player2);
            if (!stopPlaying)
            {
                PokemonInGameDeath(player2);
                ChangeTurn(player1, player2);
            }
        }
        else
        {
            player1.PokemonInGame[0].ReceiveAttack(player2.PokemonInGame[0].Attacks[num]);
            bool stopPlaying = AllPokemonDead(player1);
            if (!stopPlaying)
            {
                PokemonInGameDeath(player1);
                ChangeTurn(player1, player2);
            }
        }
        
    }

    public static void PokemonInGameDeath(Player player)
    {
        if (player.PokemonInGame[0].Life <= 0)
        {
            Pokemon delete = player.PokemonInGame[0];
            player.PokemonInGame.Remove(delete);
            player.Pokemons.Remove(delete);
            Random rnd = new Random();
            int num = rnd.Next(player.Pokemons.Count());
            
            player.SelectPokemon(player.Pokemons[num]);
        }
    }

    public static bool AllPokemonDead(Player player)
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