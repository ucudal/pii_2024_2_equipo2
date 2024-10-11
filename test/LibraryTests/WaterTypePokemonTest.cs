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
        waterType = new WaterType();
        waterTypeAttack = new Attack("Martillo de Cangrejo", 20, waterType);
        waterPokemon = new Pokemon("Squirtle", 200, waterType, new List<Attack> { waterTypeAttack }, 25);
        
        // Inicializa el tipo de fuego
        fireType = new FireType();
        fireTypeAttack = new Attack("Ascuas", 20, fireType);
        firePokemon = new Pokemon("Charizard", 200, fireType, new List<Attack> { fireTypeAttack }, 30);
        
        // Inicializa el tipo de hierba
        grassType = new GrassType();
        grassTypeAttack = new Attack("Hoja Afilada", 15, grassType);
        grassPokemon = new Pokemon("Bulbasaur", 200, grassType, new List<Attack> { grassTypeAttack }, 30);

        // Inicializa la habilidad de curación
        curation = new Heal(50);
    }

    [Test]
    public void CalculateEffectivityIsCorrect()
    {
        Assert.That(waterTypeAttack.AType.CalculateEffectivity(waterType), Is.EqualTo(1));
        Assert.That(waterTypeAttack.AType.CalculateEffectivity(fireType), Is.EqualTo(0.5)); // Agua es débil contra fuego
        Assert.That(waterTypeAttack.AType.CalculateEffectivity(grassType), Is.EqualTo(2.0)); // Agua es fuerte contra hierba
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
        Assert.That(waterPokemon.Life, Is.EqualTo(140)); // 190 - (15 * 0.5)
    }
    
    [Test]
    public void PokemonReceivesHealingCorrectly()
    {
        waterPokemon.ReceiveHealing(curation);
        Assert.That(waterPokemon.Life, Is.EqualTo(250)); // 200 + 50
    }
}
