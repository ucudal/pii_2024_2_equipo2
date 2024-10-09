using Library;
using Library.FamilyType;

namespace LibraryTests;

public class NormalTypePokemonTest
{
    // Pokemon principal al cual vamos a atacar
    private Pokemon normalPokemon;
    private NormalType normalType;
    private Attack normalTypeAttack;
   
    
    // Pokemones que van a atacar
    private Pokemon waterPokemon;
    private WaterType waterType;
    private Attack waterTypeAttack;
    
    private Pokemon firePokemon;
    private FireType fireType;
    private Attack fireTypeAttack;
     
    private Pokemon grassPokemon;
    private GrassType grassType;
    private Attack grassTypeAttack;
    
    // Habilidades
    private Heal curation;

    [SetUp]
    public void setup()
    {
        normalPokemon = new Pokemon(200, normalType, new List<Attack> { normalTypeAttack }, 5);
        normalType = new NormalType();
        normalTypeAttack = new Attack("Ataque Rápido", 5, normalType);

        waterPokemon = new Pokemon(200, waterType, new List<Attack> { waterTypeAttack }, 25);
        waterType = new WaterType();
        waterTypeAttack = new Attack("Martillo de Cangrejo", 20, waterType);
        
        firePokemon = new Pokemon(200, fireType, new List<Attack> { fireTypeAttack }, 30);
        fireType = new FireType();
        fireTypeAttack = new Attack("Ascuas", 20, fireType);
        
        grassPokemon = new Pokemon(200, grassType, new List<Attack> { grassTypeAttack }, 30);
        grassType = new GrassType();
        grassTypeAttack = new Attack("Hoja Afilada", 15, grassType);
        
        curation = new Heal(20);
    }
    
    [Test]
    public void CalculateEffecivityIsCorrect()
    {
        Assert.That(normalTypeAttack.AType.CalculateEffectivity(normalType), Is.EqualTo((1)));
        Assert.That(normalTypeAttack.AType.CalculateEffectivity(waterType), Is.EqualTo(1));
        Assert.That(normalTypeAttack.AType.CalculateEffectivity(fireType), Is.EqualTo((1)));
        Assert.That(normalTypeAttack.AType.CalculateEffectivity(grassType), Is.EqualTo((1)));
    }

    [Test]
    public void ReceiveAttackWorks()
    {
        Assert.That(normalPokemon.Life, Is.EqualTo(200));
        
        normalPokemon.ReceiveAttack(normalTypeAttack, normalType);
        Assert.That(normalPokemon.Life, Is.EqualTo(195));
        
        normalPokemon.ReceiveAttack(waterTypeAttack, waterType);
        Assert.That(normalPokemon.Life, Is.EqualTo(175));
        
        normalPokemon.ReceiveAttack(fireTypeAttack, fireType);
        Assert.That(normalPokemon.Life, Is.EqualTo(155));
        
        normalPokemon.ReceiveAttack(grassTypeAttack, grassType);
        Assert.That(normalPokemon.Life, Is.EqualTo(140));
    }
}