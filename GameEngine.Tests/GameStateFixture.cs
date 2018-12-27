using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine.Tests
{
    public class GameStateFixture : IDisposable
    {
        public GameState GameState { get; set; }
        public GameStateFixture()
        {
            GameState = new GameState();
        }
        public void Dispose()
        {
            
        }
    }
}
