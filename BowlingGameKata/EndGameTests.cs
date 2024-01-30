using BowlingGameKata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGameKata
{
    public class EndGameTests
    {
        [Fact]
        public void TenFrames()
        {
            var game = new Game();
            game.Roll(3);//Frame 1
            game.Roll(6);

            game.Roll(3);//Frame 2
            game.Roll(6);

            game.Roll(3);//Frame 3
            game.Roll(6);

            game.Roll(3);//Frame 4
            game.Roll(6);

            game.Roll(3);//Frame 5
            game.Roll(6);

            game.Roll(3);//Frame 6
            game.Roll(6);

            game.Roll(3);//Frame 7
            game.Roll(6);

            game.Roll(3);//Frame 8
            game.Roll(6);

            game.Roll(3);//Frame 9
            game.Roll(6);

            game.Roll(3);//Frame 10
            game.Roll(6);

            game.Roll(3);//Frame 11 (Shouldn't be counted)
            game.Roll(6);
            _ = game.Score();
            Assert.Equal(10, game.Frames.Count);
        }

        [Fact]
        public void TenthFrameExtraRolls()
        {
            var game = new Game();
            game.Roll(0);//Frame 1
            game.Roll(0);

            game.Roll(0);//Frame 2
            game.Roll(0);

            game.Roll(0);//Frame 3
            game.Roll(0);

            game.Roll(0);//Frame 4
            game.Roll(0);

            game.Roll(0);//Frame 5
            game.Roll(0);

            game.Roll(0);//Frame 6
            game.Roll(0);

            game.Roll(0);//Frame 7
            game.Roll(0);

            game.Roll(0);//Frame 8
            game.Roll(0);

            game.Roll(0);//Frame 9
            game.Roll(0);

            game.Roll(10);//Frame 10
            game.Roll(10);
            game.Roll(10);

            _ = game.Score();
            Assert.Equal(30, game.Score());
        }        
        
        [Fact]
        public void PerfectGameTest()
        {
            var game = new Game();
            game.Roll(10);//Frame 1
            game.Roll(10);//Frame 2
            game.Roll(10);//Frame 3
            game.Roll(10);//Frame 4
            game.Roll(10);//Frame 5
            game.Roll(10);//Frame 6
            game.Roll(10);//Frame 7
            game.Roll(10);//Frame 8
            game.Roll(10);//Frame 9

            game.Roll(10);//Frame 10
            game.Roll(10);
            game.Roll(10);

            _ = game.Score();
            Assert.Equal(300, game.Score());
            Assert.Equal(10, game.Frames.Count);
        } 
        
        [Fact]
        public void TenthFrameSpareTest()
        {
            var game = new Game();
            game.Roll(0);//Frame 1
            game.Roll(0);

            game.Roll(0);//Frame 2
            game.Roll(0);

            game.Roll(0);//Frame 3
            game.Roll(0);

            game.Roll(0);//Frame 4
            game.Roll(0);

            game.Roll(0);//Frame 5
            game.Roll(0);

            game.Roll(0);//Frame 6
            game.Roll(0);

            game.Roll(0);//Frame 7
            game.Roll(0);

            game.Roll(0);//Frame 8
            game.Roll(0);

            game.Roll(0);//Frame 9
            game.Roll(0);

            game.Roll(3);//Frame 10
            game.Roll(7);
            game.Roll(5);

            _ = game.Score();
            Assert.Equal(20, game.Score());
            Assert.Equal(10, game.Frames.Count);
        } 
        
        [Fact]
        public void NormalGameTest()
        {
            var game = new Game();
            game.Roll(0);//Frame 1 --9
            game.Roll(9);

            game.Roll(0);//Frame 2 --19/
            game.Roll(10);

            game.Roll(5);//Frame 3 --32
            game.Roll(3);

            game.Roll(4);//Frame 4 --42/
            game.Roll(6);

            game.Roll(10);//Frame 5 --62X

            game.Roll(1);//Frame 6 --74
            game.Roll(5);

            game.Roll(5);//Frame 7 --83
            game.Roll(4);

            game.Roll(3);//Frame 8 --91
            game.Roll(5);

            game.Roll(10);//Frame 9 --101X

            game.Roll(8);//Frame 10 --119
            game.Roll(1);

            //Shouldn't count this roll.
            game.Roll(5);

            _ = game.Score();
            Assert.Equal(119, game.Score());
            Assert.Equal(10, game.Frames.Count);
        } 
    }
}
