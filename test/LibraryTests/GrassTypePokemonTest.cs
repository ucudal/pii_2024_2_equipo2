using Library;
using Library.FamilyType;
using NUnit.Framework;

namespace LibraryTests
{
    public class GrassTypePokemonTest
    {
        // Pokemon principal al cual vamos a atacar
        private Pokemon grassPokemon;
        private GrassType grassType;
        private Attack grassTypeAttack;

        // Pokemones que van a atacar
        private Pokemon waterPokemon;
        private WaterType waterType;
        private Attack waterTypeAttack;

        private Pokemon firePokemon;
        private FireType fireType;
        private Attack fireTypeAttack;

        private Pokemon normalPokemon;
        private NormalType normalType;
        private Attack normalTypeAttack;

        // Habilidades
        private Heal curation;

        [SetUp]
        public void Setup()
        {
            grassType = new GrassType();
            grassTypeAttack = new Attack("Hoja Afilada", 15, grassType);
            grassPokemon = new Pokemon("Bulbasaur", 200, grassType, new List<Attack> { grassTypeAttack }, 30);

            waterType = new WaterType();
            waterTypeAttack = new Attack("Martillo de Cangrejo", 20, waterType);
            waterPokemon = new Pokemon("Squirtle", 200, waterType, new List<Attack> { waterTypeAttack }, 25);

            fireType = new FireType();
            fireTypeAttack = new Attack("Ascuas", 20, fireType);
            firePokemon = new Pokemon("Charizard", 200, fireType, new List<Attack> { fireTypeAttack }, 30);

            normalType = new NormalType();
            normalTypeAttack = new Attack("Ataque Rápido", 5, normalType);
            normalPokemon = new Pokemon("Eevee", 200, normalType, new List<Attack> { normalTypeAttack }, 5);

            curation = new Heal(20);
        }

        [Test]
        public void CalculateEffecivityIsCorrect()
        {
            Assert.That(grassTypeAttack.AType.CalculateEffectivity(grassType), Is.EqualTo(1));
            Assert.That(grassTypeAttack.AType.CalculateEffectivity(waterType), Is.EqualTo(0.5));
            Assert.That(grassTypeAttack.AType.CalculateEffectivity(fireType), Is.EqualTo(2.0));
            Assert.That(grassTypeAttack.AType.CalculateEffectivity(normalType), Is.EqualTo(1));
        }

        [Test]
        public void ReceiveAttackWorks()
        {
            Assert.That(grassPokemon.Life, Is.EqualTo(200));

            grassPokemon.ReceiveAttack(grassTypeAttack);
            Assert.That(grassPokemon.Life, Is.EqualTo(185));

            grassPokemon.ReceiveAttack(waterTypeAttack);
            Assert.That(grassPokemon.Life, Is.EqualTo(175));

            grassPokemon.ReceiveAttack(fireTypeAttack);
            Assert.That(grassPokemon.Life, Is.EqualTo(135));

            grassPokemon.ReceiveAttack(normalTypeAttack);
            Assert.That(grassPokemon.Life, Is.EqualTo(130));
        }

        [Test]
        public void IncreaseSpeedWorksCorrectly()
        {
            grassPokemon.IncreaseSpeed(20);
            Assert.That(grassPokemon.Speed, Is.EqualTo(36));

            grassPokemon.IncreaseSpeed(50);
            Assert.That(grassPokemon.Speed, Is.EqualTo(54));
        }

        [Test]
        public void PokemonReceivesHealingCorrectly()
        {
            Heal healAbility = new Heal("Poción", 50, grassType);
            grassPokemon.ReceiveHealing(healAbility);
            Assert.That(grassPokemon.Life, Is.EqualTo(250));
        }
    }
}