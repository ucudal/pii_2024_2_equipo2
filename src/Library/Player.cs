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
    
}