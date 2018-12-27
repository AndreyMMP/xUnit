using Xunit;

namespace GameEngine.Tests
{
    public class GameStateShould
    {
        private readonly GameState _sut;
        private readonly PlayerCharacter playerCharacter1;
        private readonly PlayerCharacter playerCharacter2;
        
        public GameStateShould()
        {            
            _sut = new GameState();
            playerCharacter1 = new PlayerCharacter();
            playerCharacter2 = new PlayerCharacter();
            AddPlayersToTheWorld();
        }

        private void AddPlayersToTheWorld()
        {            
            _sut.Players.Add(playerCharacter1);
            _sut.Players.Add(playerCharacter2);
        }

        [Fact]
        public void DamageAllPlayersWhenEarthquake()
        {
            int expectedHealthAfterEarthquake = playerCharacter1.Health - GameState.EarthquakeDamage;

            _sut.Earthquake();

            Assert.Equal(expectedHealthAfterEarthquake, playerCharacter1.Health);
            Assert.Equal(expectedHealthAfterEarthquake, playerCharacter2.Health);
        }
        [Fact]
        public void Reset()
        {
            _sut.Reset();

            Assert.Empty(_sut.Players);
        }
    }
}
