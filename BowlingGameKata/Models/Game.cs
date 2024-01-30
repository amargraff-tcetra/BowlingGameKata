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
        public List<int> Rolls { get; set; }= new List<int>();
        public List<Frame> Frames { get; set; } = new List<Frame>();
        private Frame CurrentFrame { get; set; } = new Frame();

        public Game()
        {
        }

        public void Roll(int pins)
        {
            Rolls.Add(pins);
        }

        public int Score()
        {
            var finalScore = 0;
            foreach(var r in Rolls.Select((r,i) => new { roll = r, index = i}))
            {
                CurrentFrame.Rolls.Add(r.roll);

                //Check if frame complete
                if (CurrentFrame.Rolls.Sum() == PIN_COUNT || CurrentFrame.Rolls.Count == ALLOWED_ROLLS)
                {
                    //Spare
                    if (CurrentFrame.Rolls.Sum() == PIN_COUNT && CurrentFrame.Rolls.Count == ALLOWED_ROLLS)
                    {
                        CurrentFrame.Bonus = Rolls.ElementAtOrDefault(r.index + 1);//Next ball counts as bonus
                    }

                    //Strike
                    if (CurrentFrame.Rolls.Sum() == PIN_COUNT && CurrentFrame.Rolls.Count < ALLOWED_ROLLS)
                    {
                        CurrentFrame.Bonus = Rolls.ElementAtOrDefault(r.index + 1) + Rolls.ElementAtOrDefault(r.index + 2);//Next two balls count as bonus
                    }

                    Frames.Add(CurrentFrame);
                    CurrentFrame = new Frame();
                }
            }

            //Total Finished Frames
            Frames.ForEach(f => finalScore += f.Score);

            //Unfinished Game
            if (Frames.Count < 10)
            {
                finalScore += CurrentFrame.Score;
            }

            return finalScore;
        }
    }
}
