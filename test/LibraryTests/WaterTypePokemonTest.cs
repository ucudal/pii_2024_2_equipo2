using Library;
using Library.FamilyType;

namespace LibraryTests;

public class WaterTypePokemonTest
{
    // Pokemon principal al cual vamos a atacar
    private Pokemon waterPokemon;
    private WaterType waterType;
    private Attack waterTypeAttack;
    
    // Pokemones que van a atacar
    private Pokemon firePokemon;
    private FireType fireType;
    private Attack fireTypeAttack;
     
    private Pokemon grassPokemon;
    private GrassType grassType;
    private Attack grassTypeAttack;
   
    private Pokemon normalPokemon;
    private NormalType normalType;
    private Attack normalTypeAttack;
    
    // Habilidades
    private Heal curation;

    [SetUp]
    public void setup()
    {
        waterPokemon = new Pokemon(200, waterType, new List<Attack> { waterTypeAttack }, 25);
        waterType = new WaterType();
        waterTypeAttack = new Attack("Martillo de Cangrejo", 20, waterType);
        
        firePokemon = new Pokemon(200, fireType, new List<Attack> { fireTypeAttack }, 30);
        fireType = new FireType();
        fireTypeAttack = new Attack("Ascuas", 20, fireType);
        
        grassPokemon = new Pokemon(200, grassType, new List<Attack> { grassTypeAttack }, 30);
        grassType = new GrassType();
        grassTypeAttack = new Attack("Hoja Afilada", 15, grassType);
        
        normalPokemon = new Pokemon(200, normalType, new List<Attack> { normalTypeAttack }, 5);
        normalType = new NormalType();
        normalTypeAttack = new Attack("Ataque Rápido", 5, normalType);
        
        curation = new Heal(20);
    }
    
    [Test]
    public void CalculateEffecivityIsCorrect()
    {
        Assert.That(waterTypeAttack.AType.CalculateEffectivity(waterType), Is.EqualTo((1)));
        Assert.That(waterTypeAttack.AType.CalculateEffectivity(fireType), Is.EqualTo(0.5));
        Assert.That(waterTypeAttack.AType.CalculateEffectivity(grassType), Is.EqualTo((2)));
        Assert.That(waterTypeAttack.AType.CalculateEffectivity(normalType), Is.EqualTo((1)));
    }

    [Test]
    public void ReceiveAttackWorks()
    {
        Assert.That(waterPokemon.Life, Is.EqualTo(200));
        
        waterPokemon.ReceiveAttack(waterTypeAttack, waterType);
        Assert.That(waterPokemon.Life, Is.EqualTo(180));
        
        waterPokemon.ReceiveAttack(fireTypeAttack, fireType);
        Assert.That(waterPokemon.Life, Is.EqualTo(160));
        
        waterPokemon.ReceiveAttack(grassTypeAttack, grassType);
        Assert.That(waterPokemon.Life, Is.EqualTo(145));
        
        waterPokemon.ReceiveAttack(normalTypeAttack, normalType);
        Assert.That(waterPokemon.Life, Is.EqualTo(140));
    }
}