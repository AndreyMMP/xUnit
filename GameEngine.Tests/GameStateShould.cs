using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests
{
    public class GameStateShould : IClassFixture<GameStateFixture>
    {
        private readonly GameStateFixture _gameStateFixture;
        private readonly ITestOutputHelper _output;
        private readonly PlayerCharacter playerCharacter1;
        private readonly PlayerCharacter playerCharacter2;
        
        
        public GameStateShould(GameStateFixture gameStateFixture, ITestOutputHelper output)
        {
            _gameStateFixture = gameStateFixture;

            _output = output;

            playerCharacter1 = new PlayerCharacter();
            playerCharacter2 = new PlayerCharacter();

            AddPlayersToTheWorld();
        }

        private void AddPlayersToTheWorld()
        {
            _gameStateFixture.GameState.Players.Add(playerCharacter1);
            _gameStateFixture.GameState.Players.Add(playerCharacter2);
        }

        [Fact]
        public void DamageAllPlayersWhenEarthquake()
        {
            _output.WriteLine($"GameState ID={_gameStateFixture.GameState.Id}");

            int expectedHealthAfterEarthquake = playerCharacter1.Health - GameState.EarthquakeDamage;

            _gameStateFixture.GameState.Earthquake();

            Assert.Equal(expectedHealthAfterEarthquake, playerCharacter1.Health);
            Assert.Equal(expectedHealthAfterEarthquake, playerCharacter2.Health);
        }
        [Fact]
        public void Reset()
        {
            _output.WriteLine($"GameState ID={_gameStateFixture.GameState.Id}");

            _gameStateFixture.GameState.Reset();

            Assert.Empty(_gameStateFixture.GameState.Players);
        }
    }
}
