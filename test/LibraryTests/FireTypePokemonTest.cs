using Library;
using Library.FamilyType;

namespace LibraryTests;

public class FireTypePokemonTest
{
    private FireType fireType;
    private Attack fireTypeAttack;
    
    private WaterType waterType;
    private GrassType grassType;
    private NormalType normalType;

    [SetUp]
    
    public void setup()
    {
        fireType = new FireType();
        fireTypeAttack = new Attack("Colmillo Ígneo", 20, fireType);
    }

    [Test]
    public void firetypeAttackCreatedCorrectly()
    {
        Assert.That(fireTypeAttack.Name, Is.EqualTo("Colmillo Ígneo"));
        Assert.That(fireTypeAttack.Damage, Is.EqualTo(20));
        Assert.That(fireTypeAttack.AType, Is.EqualTo(fireType));
    }

    public void CalculateEffecivityIsCorrect()
    {
        Assert.That(fireTypeAttack.AType.CalculateEffectivity(waterType), Is.EqualTo((40)));
        Assert.That(fireTypeAttack.AType.CalculateEffectivity(grassType), Is.EqualTo((10)));
        Assert.That(fireTypeAttack.AType.CalculateEffectivity(normalType), Is.EqualTo((20)));
    }
}