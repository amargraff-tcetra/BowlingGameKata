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
        public List<Frame> Frames { get; set; } = new List<Frame>();
        private Frame CurrentFrame { get; set; } = new Frame();

        public Game()
        {
        }

        public void Roll(int pins)
        {
            if (CurrentFrame.Rolls.Count < ALLOWED_ROLLS && CurrentFrame.Rolls.Sum() < PIN_COUNT)
            {
                CurrentFrame.Rolls.Add(pins);

            }

            if (CurrentFrame.Rolls.Count == ALLOWED_ROLLS || CurrentFrame.Rolls.Sum() == PIN_COUNT)
            {
                Frames.Add(CurrentFrame);
                CurrentFrame = new Frame();
            }
        }

        public int Score()
        {
            var finalScore = 0;
            foreach (var f in Frames.Select((f,i) => new { frame = f, Index = i }))
            {
                //Calculate Bonus
                if (f.frame.Rolls.Sum() == PIN_COUNT)
                {
                    if(Frames.Count > f.Index + 1) 
                    { 
                        f.frame.Bonus = Frames[f.Index + 1].Rolls[0];
                    }
                    else
                    {
                        f.frame.Bonus = CurrentFrame.Rolls[0];
                    }
                }

                //Add Frame to FinalScore
                finalScore += f.frame.Score;
            }

            return finalScore + CurrentFrame.Score;
        }
    }
}
