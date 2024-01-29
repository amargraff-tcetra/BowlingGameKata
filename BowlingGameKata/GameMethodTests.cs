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
        public void RollAndScoreTest()
        {
            var game = new Game();
            game.Roll(5);
            Assert.Equal(5, game.Score());
        }
    }
}
