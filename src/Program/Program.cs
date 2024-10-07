using Library;

public class Program
{
    public static void Main()
    { 
        FamilyType Grass = new FamilyType("Grass");
        FamilyType Water = new FamilyType("Water");
        FamilyType Fire = new FamilyType("Fire");
        FamilyType Normal = new FamilyType("Normal");

        Attack Ember = new Attack(Fire, 50);
        Attack Scratch = new Attack(Normal, 30);
        Attack Flamethrower = new Attack(Fire, 90);
        Attack FireFang = new Attack(Fire, 65);

        Pokemon Charmander = new Pokemon(200, Fire, new List<Attack> { Ember, Scratch, Flamethrower, FireFang }, 30);
    }
}

