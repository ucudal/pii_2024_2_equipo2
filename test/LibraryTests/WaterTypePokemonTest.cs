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

    [SetUp]

    public void setup()
    {
        waterPokemon = new Pokemon(200, waterType, new List<Attack> { waterTypeAttack }, 25);
        firePokemon = new Pokemon(200, fireType, new List<Attack> { fireTypeAttack }, 30);
        grassPokemon = new Pokemon(200, grassType, new List<Attack> { grassTypeAttack }, 30);
        normalPokemon = new Pokemon(200, normalType, new List<Attack> { normalTypeAttack }, 5);
    }
    
    [Test]
    public void watertypePokemonCreatedCorrectly()
    {
        Assert.That(waterPokemon.Life, Is.EqualTo(200));
        Assert.That(waterPokemon.PType, Is.EqualTo(waterType));
        Assert.That(waterPokemon.Attacks, Is.EqualTo(List<Attack> { waterTypeAttack }));
        Assert.That(waterPokemon.Speed, Is.EqualTo(25));
    }

    public void CalculateEffecivityIsCorrect()
    {
        Assert.That(waterTypeAttack.AType.CalculateEffectivity(waterType), Is.EqualTo((40)));
        Assert.That(waterTypeAttack.AType.CalculateEffectivity(grassType), Is.EqualTo((10)));
        Assert.That(waterTypeAttack.AType.CalculateEffectivity(normalType), Is.EqualTo((20)));
    }
}