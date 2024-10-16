﻿using Library;
using Library.FamilyType;

namespace LibraryTests;

public class FireTypePokemonTest
{
    // Pokemon principal al cual vamos a atacar
    private Pokemon firePokemon;
    private FireType fireType;
    private Attack fireTypeAttack;
    
    // Pokemones que van a atacar
    private Pokemon waterPokemon;
    private WaterType waterType;
    private Attack waterTypeAttack;
     
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
        firePokemon = new Pokemon("Charizard", 200, fireType, new List<Attack> { fireTypeAttack }, 30);
        fireType = new FireType();
        fireTypeAttack = new Attack("Ascuas", 20, fireType);
        
        normalPokemon = new Pokemon("Eevee", 200, normalType, new List<Attack> { normalTypeAttack }, 5);
        normalType = new NormalType();
        normalTypeAttack = new Attack("Ataque Rápido", 5, normalType);
        
        waterPokemon = new Pokemon("Squirtle", 200, waterType, new List<Attack> { waterTypeAttack }, 25);
        waterType = new WaterType();
        waterTypeAttack = new Attack("Martillo de Cangrejo", 20, waterType);
        
        grassPokemon = new Pokemon("Bulbasaur", 200, grassType, new List<Attack> { grassTypeAttack }, 30);
        grassType = new GrassType();
        grassTypeAttack = new Attack("Hoja Afilada", 15, grassType);
        
        curation = new Heal(20);
    }

    [Test]
    public void CalculateEffecivityIsCorrect()
    {
        Assert.That(fireTypeAttack.AType.CalculateEffectivity(fireType), Is.EqualTo(1));
        Assert.That(fireTypeAttack.AType.CalculateEffectivity(waterType), Is.EqualTo(2));
        Assert.That(fireTypeAttack.AType.CalculateEffectivity(grassType), Is.EqualTo(0.5));
        Assert.That(fireTypeAttack.AType.CalculateEffectivity(fireType), Is.EqualTo(1));
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