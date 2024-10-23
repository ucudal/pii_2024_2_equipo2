using Library;
using Library.FamilyType;
using Library.Interfaces;

namespace LibraryTests;

public class FireTypePokemonTest
{
    // Pokemon principal al cual vamos a atacar
    private Pokemon firePokemon;
    private IType fireType;
    private Attack fireTypeAttack;
    
    // Pokemones que van a atacar
    private Pokemon waterPokemon;
    private IType waterType;
    private Attack waterTypeAttack;
     
    private Pokemon grassPokemon;
    private IType grassType;
    private Attack grassTypeAttack;
   
    private Pokemon normalPokemon;
    private IType normalType;
    private Attack normalTypeAttack;
    
    // Habilidades
    private Heal curation;

    [SetUp]
    public void setup()
    {
        // TYPES
        fireType =  FireType.GetInstance();
        normalType =  NormalType.GetInstance();
        waterType =  WaterType.GetInstance();
        grassType =  GrassType.GetInstance();

        //TYPE ATTACKS
        fireTypeAttack = new Attack("Ascuas", 20, fireType);
        normalTypeAttack = new Attack("Ataque Rápido", 5, normalType);
        waterTypeAttack = new Attack("Martillo de Cangrejo", 20, waterType);
        grassTypeAttack = new Attack("Hoja Afilada", 15, grassType);

        //POKEMONS
        firePokemon = new Pokemon("Charizard", 200, fireType, new List<Attack> { fireTypeAttack }, 30);
        normalPokemon = new Pokemon("Eevee", 200, normalType, new List<Attack> { normalTypeAttack }, 5);
        waterPokemon = new Pokemon("Squirtle", 200, waterType, new List<Attack> { waterTypeAttack }, 25);
        grassPokemon = new Pokemon("Bulbasaur", 200, grassType, new List<Attack> { grassTypeAttack }, 30);
        
        curation = new Heal(20);
    }

    [Test]
    public void CalculateEffectivityIsCorrect()
    {
        // Crear una instancia de Effectivity para usar en las pruebas
        var effectivity = new Effectivity();

        // Probar la efectividad de los ataques usando la clase Effectivity
        Assert.That(effectivity.CalculateEffectivity(fireTypeAttack.AType, fireType), Is.EqualTo(1.0f));
        Assert.That(effectivity.CalculateEffectivity(fireTypeAttack.AType, waterType), Is.EqualTo(0.5f));
        Assert.That(effectivity.CalculateEffectivity(fireTypeAttack.AType, grassType), Is.EqualTo(2.0f));
        Assert.That(effectivity.CalculateEffectivity(fireTypeAttack.AType, normalType), Is.EqualTo(1.0f));
    }
    
    [Test]
    public void IncreaseSpeedWorksCorrectly()
    {
        firePokemon.IncreaseSpeed(20);
        Assert.That(firePokemon.Speed, Is.EqualTo(36));

        firePokemon.IncreaseSpeed(50);
        Assert.That(firePokemon.Speed, Is.EqualTo(54));
    }

    [Test]
    public void PokemonReceivesHealingCorrectly()
    {
        Heal healAbility = new Heal("Poción", 50, fireType);
        firePokemon.ReceiveHealing(healAbility);
        Assert.That(firePokemon.Life, Is.EqualTo(250));
    }

    
    
}