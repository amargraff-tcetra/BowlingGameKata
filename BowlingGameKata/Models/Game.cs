using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGameKata.Models
{
    public class Game
    {
        private static readonly int PIN_COUNT = 10;
        private static readonly int ALLOWED_ROLLS = 2;
        private int _score { get; set; }
        public List<Frame> Frames { get; set; } = new List<Frame>();
        private Frame CurrentFrame { get; set; } = new Frame();

        public Game()
        {
            _score = 0;
        }

        public void Roll(int pins)
        {
            if (CurrentFrame.Rolls.Count < ALLOWED_ROLLS && CurrentFrame.Score < PIN_COUNT)
            {
                CurrentFrame.Rolls.Add(pins);
                if (CurrentFrame.Rolls.Count == ALLOWED_ROLLS || CurrentFrame.Score == PIN_COUNT)
                {
                    Frames.Add(CurrentFrame);
                    CurrentFrame = new Frame();
                }
            }
            else {
                CurrentFrame.Rolls.Add(pins);
            }
        }

        public int Score()
        {
            return _score + CurrentFrame.Score;
        }
    }
}
