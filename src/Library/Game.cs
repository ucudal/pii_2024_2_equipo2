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
        Attack LeechSeed = new Attack("LeachSeed", 0, Grass);

        Pokemon Bulbasaur = new Pokemon("Bulbasaur",200, Grass, new List<Attack> { VineWhip, Tackle, SolarBeam, LeechSeed }, 30);
        Pokemon Squirtle = new Pokemon("Squirtle",200, Water, new List<Attack> { WaterGun, Tackle, Bubble, AquaJet }, 25);
        Pokemon Charmander = new Pokemon("Charmander",200, Fire, new List<Attack> { Ember, Scratch, Flamethrower, FireFang }, 30);
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
        
        Player1.SelectPokemon(Bulbasaur);
        Player2.SelectPokemon(Charmander);

        UseTurn(Player1, Player2);
        Console.WriteLine(Player2.PokemonInGame[0].Life);

    }

    public void WhoStarts(Player player1, Player player2)
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

    public void ChangeTurn(Player player1, Player player2)
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

    public void UseTurn(Player player1, Player player2)
    {
        Random rnd = new Random();
        int num = rnd.Next();
        
        if (player1.Turn)
        {
            player2.PokemonInGame[0].ReceiveAttack(player1.PokemonInGame[0].Attacks[num]);
            ChangeTurn(player1, player2);
        }
        else
        {
            player1.PokemonInGame[0].ReceiveAttack(player2.PokemonInGame[0].Attacks[num]);
            ChangeTurn(player1, player2);
        }
        
    }

    public void PokemonInGameDeath(Player player)
    {
        if (player.PokemonInGame[0].Life <= 0)
        {
            Random rnd = new Random();
            int num = rnd.Next(player.Pokemons.Count());
            
            
        }
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