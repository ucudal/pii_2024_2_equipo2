namespace Library;

public class Player
{
    public string Name;
    public List<Pokemon> Pokemons { get; set; }

    public Player(string name)
    {
        this.Name = name;
        this.Pokemons = new List<Pokemon>();
    }

    public void AddPokemon(Pokemon pokemon)
    {
        if (this.Pokemons.Count() < 6)
        {
            this.Pokemons.Add(pokemon);
        }
    }
}