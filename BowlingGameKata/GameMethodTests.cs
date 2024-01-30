using BowlingGameKata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGameKata
{
    public class GameMethodTests
    {
        [Fact]
        public void RollTest()
        {
            var game = new Game();
            game.Roll(5);
            Assert.Equal(5, game.Score());
        }

        [Fact]
        public void NewFrameTest()
        {
            Game game = new Game();
            game.Roll(5);
            game.Roll(3);
            _ = game.Score();
            Assert.Single(game.Frames);
        }
    }
}
