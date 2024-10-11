using Library.FamilyType;

namespace Library.Tests
{
    [TestFixture]
    public class GameTests
    {
        private Game game;
        
        private Pokemon waterPokemon1;
        private Pokemon waterPokemon2;
        private WaterType waterType;
        private Attack waterTypeAttack1;
        private Attack waterTypeAttack2;
        private Attack waterTypeAttack3;
        private Attack waterTypeAttack4;
        private Attack waterTypeAttack5;
        private Attack waterTypeAttack6;
        
        private Pokemon firePokemon1;
        private Pokemon firePokemon2;
        private FireType fireType;
        private Attack fireTypeAttack1;
        private Attack fireTypeAttack2;
        private Attack fireTypeAttack3;
        private Attack fireTypeAttack4;
        private Attack fireTypeAttack5;
        private Attack fireTypeAttack6;
        
        private Player player1;
        private Player player2;

        [SetUp]
        public void Setup()
        {
            game = new Game();
            
            waterType = new WaterType();
            waterTypeAttack1 = new Attack("Martillo de Cangrejo", 20, waterType);
            waterTypeAttack2 = new Attack("Chorro de Agua", 15, waterType);
            waterTypeAttack3 = new Attack("Burbuja Explosiva", 25, waterType);
            waterTypeAttack4 = new Attack("Tsunami", 30, waterType);
            waterTypeAttack5 = new Attack("Rayo Acuático", 35, waterType);
            waterTypeAttack6 = new Attack("Tenaza", 40, waterType);
            
            waterPokemon1 = new Pokemon("Squirtle", 200, waterType, new List<Attack> { waterTypeAttack1, waterTypeAttack2, waterTypeAttack3 }, 25);
            waterPokemon2 = new Pokemon("Wailord", 200, waterType, new List<Attack> { waterTypeAttack4, waterTypeAttack5, waterTypeAttack6 }, 30);
            
            fireType = new FireType();
            fireTypeAttack1 = new Attack("Ascuas", 20, fireType);
            fireTypeAttack2 = new Attack("Llama Fulgurante", 25, fireType);
            fireTypeAttack3 = new Attack("Fogonazo", 30, fireType);
            fireTypeAttack4 = new Attack("Lluvia de Fuego", 40, fireType);
            
            firePokemon1 = new Pokemon("Charmander", 200, fireType, new List<Attack> { fireTypeAttack1, fireTypeAttack2, fireTypeAttack3 }, 5);
            firePokemon2 = new Pokemon("Charizard", 200, fireType, new List<Attack> { fireTypeAttack4, fireTypeAttack5, fireTypeAttack6 }, 10);
            
            player1 = new Player("Ash") { Pokemons = new List<Pokemon> { waterPokemon1, firePokemon1 }, PokemonInGame = new List<Pokemon> { waterPokemon1 }, Turn = false };
            player2 = new Player("Misty") { Pokemons = new List<Pokemon> { waterPokemon2, firePokemon2 }, PokemonInGame = new List<Pokemon> { firePokemon2 }, Turn = false };
        }

        [Test]
        public void WhoStarts_Player1Faster_Player1Starts()
        {
            game.WhoStarts(player1, player2);
            Assert.IsTrue(player1.Turn);
            Assert.IsFalse(player2.Turn);
        }

        [Test]
        public void WhoStarts_Player2Faster_Player2Starts()
        {
            game.WhoStarts(player1, player2);
            Assert.IsTrue(player1.Turn);
            Assert.IsFalse(player2.Turn);
        }

        [Test]
        public void ChangeTurn_Player1Turn_Player2Turn()
        {
            player1.Turn = true;
            game.ChangeTurn(player1, player2);
            Assert.IsFalse(player1.Turn);
            Assert.IsTrue(player2.Turn);
        }

        [Test]
        public void ChangeTurn_Player2Turn_Player1Turn()
        {
            player2.Turn = true;
            game.ChangeTurn(player1, player2);
            Assert.IsTrue(player1.Turn);
            Assert.IsFalse(player2.Turn);
        }

        [Test]
        public void UseTurn_Player1Attacks_Player2ReceivesDamage()
        {
            player1.Turn = true;
            game.UseTurn(player1, player2);
            
            Assert.That(player2.PokemonInGame[0].Life, Is.Not.EqualTo(200));
            
            Assert.IsFalse(player1.Turn);
            Assert.IsTrue(player2.Turn);
        }

        [Test]
        public void UseTurn_Player2Attacks_Player1ReceivesDamage()
        {
            player2.Turn = true;
            game.UseTurn(player1, player2);
            
            Assert.That(player1.PokemonInGame[0].Life, Is.Not.EqualTo(200));
            
            Assert.IsTrue(player1.Turn);
            Assert.IsFalse(player2.Turn);
        }

        [Test]
        public void PokemonInGameDeath_PokemonDead_NoAction()
        {
            waterPokemon1.Life = 0;
            game.PokemonInGameDeath(player1);
        }

        [Test]
        public void AllPokemonDead_AllDead_ReturnsTrue()
        {
            waterPokemon1.Life = 0;
            firePokemon1.Life = 0;

            waterPokemon2.Life = 0;
            firePokemon2.Life = 0;
            
            Assert.IsTrue(game.AllPokemonDead(player1));
            Assert.IsTrue(game.AllPokemonDead(player2));
        }

        [Test]
        public void AllPokemonDead_OneAlive_ReturnsFalse()
        {
            waterPokemon1.Life = 0;
            firePokemon1.Life = 100;

            waterPokemon2.Life = 100;
            firePokemon2.Life = 0;
            
            Assert.IsFalse(game.AllPokemonDead(player1));
            Assert.IsFalse(game.AllPokemonDead(player2));
        }
    }
}
