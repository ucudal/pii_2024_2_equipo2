namespace Library;

public class Player
{
    private string Name;
    private List<Pokemon> Pokemons { get; set; }

    public Player(string name)
    {
        this.Name = name;
        this.Pokemons = new List<Pokemon>;
    }
    
}