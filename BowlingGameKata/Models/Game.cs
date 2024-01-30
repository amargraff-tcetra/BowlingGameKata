using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace BowlingGameKata.Models
{
    public class Game
    {
        private static readonly int PIN_COUNT = 10;
        private static readonly int ALLOWED_ROLLS = 2;
        private static readonly int ALLOWED_FRAMES = 10;
        public List<int> Rolls { get; set; }= new List<int>();
        public List<Frame> Frames { get; set; } = new List<Frame>();
        private Frame CurrentFrame { get; set; } = new Frame();

        public Game()
        {
        }

        public void Roll(int pins)
        {
            if (Frames.Count < ALLOWED_FRAMES)
            {
                Rolls.Add(pins);
            }
            _ = Score();
        }

        public int Score()
        {
            //Reset
            Frames = new List<Frame>();
            CurrentFrame = new Frame();
            var finalScore = 0;

            foreach(var roll in Rolls.Select((r,i) => new { value = r, index = i}))
            {
                CurrentFrame.Rolls.Add(roll.value);

                //Frame complete
                if (CurrentFrame.Rolls.Sum() == PIN_COUNT || CurrentFrame.Rolls.Count == ALLOWED_ROLLS)
                {
                    //Spare
                    if (CurrentFrame.Rolls.Sum() == PIN_COUNT && CurrentFrame.Rolls.Count == ALLOWED_ROLLS)
                    {
                        CurrentFrame.Bonus = Rolls.ElementAtOrDefault(roll.index + 1);//Next roll counts as bonus
                    }

                    //Strike
                    if (CurrentFrame.Rolls.Sum() == PIN_COUNT && CurrentFrame.Rolls.Count < ALLOWED_ROLLS)
                    {
                        CurrentFrame.Bonus = Rolls.ElementAtOrDefault(roll.index + 1) + Rolls.ElementAtOrDefault(roll.index + 2);//Next two rolls count as bonus
                    }

                    Frames.Add(CurrentFrame);
                    CurrentFrame = new Frame();
                }
            }

            //Total Finished Frames
            Frames.ForEach(f => finalScore += f.Score);

            //Unfinished Game
            if (Frames.Count < ALLOWED_FRAMES)
            {
                finalScore += CurrentFrame.Score;
            }

            return finalScore;
        }
    }
}
