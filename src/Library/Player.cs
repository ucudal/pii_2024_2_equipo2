namespace Library;

public class Player
{
    public string Name;
    public List<Pokemon> Pokemons { get; set; }

    public List<Pokemon> PokemonInGame { get; set; }

    public bool Turn { get; set; }

    public Player(string name)
    {
        this.Name = name;
        this.Pokemons = new List<Pokemon>();
        this.PokemonInGame = new List<Pokemon>();
        this.Turn = false;
    }

    public void AddPokemon(Pokemon pokemon)
    {
        if (this.Pokemons.Count() < 6)
        {
            this.Pokemons.Add(pokemon);
        }
    }

    public void SelectPokemon(Pokemon pokemon)
    {
        if (this.PokemonInGame.Count() <= 0)
        {
            PokemonInGame.Add(pokemon);
        }
    }
    public void ChangePokemon(Pokemon pokemon)
    {

    }
}