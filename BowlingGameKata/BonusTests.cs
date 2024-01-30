using BowlingGameKata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGameKata
{
    public class BonusTests
    {
        [Fact]
        public void SpareBonusTest()
        {
            Game game = new Game();
            game.Roll(6);
            game.Roll(4);
            game.Roll(7);
            Assert.Equal(24, game.Score());
        }

        [Fact]
        public void StrikeBonusTest()
        {
            Game game = new Game();
            game.Roll(10);
            game.Roll(3);
            game.Roll(5);
            Assert.Equal(26, game.Score());
        }
    }
}
