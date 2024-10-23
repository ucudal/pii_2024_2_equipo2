using Library;
using Library.FamilyType;

namespace LibraryTests;

public class WaterTypePokemonTest
{
    private Pokemon waterPokemon;
    private WaterType waterType;
    private Attack waterTypeAttack;
    
    private Pokemon firePokemon;
    private FireType fireType;
    private Attack fireTypeAttack;
     
    private Pokemon grassPokemon;
    private GrassType grassType;
    private Attack grassTypeAttack;

    private Heal curation;

    [SetUp]
    public void Setup()
    {
        // Inicializa el tipo de agua
        waterType =  WaterType.GetInstance();
        waterTypeAttack = new Attack("Martillo de Cangrejo", 20, waterType);
        waterPokemon = new Pokemon("Squirtle", 200, waterType, new List<Attack> { waterTypeAttack }, 25);
        
        // Inicializa el tipo de fuego
        fireType =  FireType.GetInstance();
        fireTypeAttack = new Attack("Ascuas", 20, fireType);
        firePokemon = new Pokemon("Charizard", 200, fireType, new List<Attack> { fireTypeAttack }, 30);
        
        // Inicializa el tipo de hierba
        grassType =  GrassType.GetInstance();
        grassTypeAttack = new Attack("Hoja Afilada", 15, grassType);
        grassPokemon = new Pokemon("Bulbasaur", 200, grassType, new List<Attack> { grassTypeAttack }, 30);

        // Inicializa la habilidad de curación
        curation = new Heal(50);
    }

    [Test]
    public void CalculateEffectivityIsCorrect()
    {
        var effectivity = new Effectivity();

        // Verificar los casos de efectividad
        var result1 = effectivity.CalculateEffectivity(fireTypeAttack.AType, waterType);
        Console.WriteLine($"Effectivity of fire against water: {result1}");
        Assert.That(result1, Is.EqualTo(0.5f));

        var result2 = effectivity.CalculateEffectivity(waterTypeAttack.AType, fireType);
        Console.WriteLine($"Effectivity of water against fire: {result2}");
        Assert.That(result2, Is.EqualTo(2.0f));

        var result3 = effectivity.CalculateEffectivity(grassTypeAttack.AType, fireType);
        Console.WriteLine($"Effectivity of grass against fire: {result3}");
        Assert.That(result3, Is.EqualTo(0.5f));

        var result4 = effectivity.CalculateEffectivity(fireTypeAttack.AType, fireType);
        Console.WriteLine($"Effectivity of fire against fire: {result4}");
        Assert.That(result4, Is.EqualTo(1.0f));
    }


    [Test]
    public void ReceiveAttackWorks()
    {
        // Comprobamos la vida inicial
        Assert.That(waterPokemon.Life, Is.EqualTo(200));
        
        // Ataque de tipo agua (efectividad 1 contra sí mismo)
        waterPokemon.ReceiveAttack(waterTypeAttack);
        Assert.That(waterPokemon.Life, Is.EqualTo(180));
        
        // Ataque de tipo fuego (efectividad 0.5 contra agua)
        waterPokemon.ReceiveAttack(fireTypeAttack);
        Assert.That(waterPokemon.Life, Is.EqualTo(170));
        
        // Ataque de tipo hierba (efectividad 2.0 contra agua)
        waterPokemon.ReceiveAttack(grassTypeAttack);
        Assert.That(waterPokemon.Life, Is.EqualTo(140)); // 
    }
    
    [Test]
    public void PokemonReceivesHealingCorrectly()
    {
        waterPokemon.ReceiveHealing(curation);
        Assert.That(waterPokemon.Life, Is.EqualTo(250)); // 200 + 50
    }
}
