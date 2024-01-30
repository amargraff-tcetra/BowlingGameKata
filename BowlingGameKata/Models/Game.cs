using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace BowlingGameKata.Models
{
    public class Game
    {
        private static readonly int PIN_COUNT = 10;
        private static readonly int ALLOWED_ROLLS = 2;
        private static readonly int ALLOWED_TENTH_FRAME_ROLLS = 3;
        private static readonly int ALLOWED_FRAMES = 10;
        public List<int> Rolls { get; set; }= new List<int>();
        public List<Frame> Frames { get; set; } = new List<Frame>();

        public Game()
        {
        }

        public void Roll(int pins)
        {
            if (Frames.Count < ALLOWED_FRAMES)
            {
                Rolls.Add(pins);
            }
            //Running Score
            _ = Score();
        }

        public int Score()
        {
            //Reset
            Frames = new List<Frame>();
            var currentFrame = new Frame();
            var finalScore = 0;

            foreach(var roll in Rolls.Select((r,i) => new { value = r, index = i}))
            {
                currentFrame.Rolls.Add(roll.value);

                var spare = currentFrame.Rolls.Count == ALLOWED_ROLLS && currentFrame.Rolls.Take(2).Sum() == PIN_COUNT;
                var strike = currentFrame.Rolls.Count == 1 && currentFrame.Rolls.Sum() == PIN_COUNT;
                var tenthFrameBonusRoll = Frames.Count + 1 == ALLOWED_FRAMES && (spare || strike);

                //Frame complete
                if (currentFrame.Rolls.Sum() == PIN_COUNT || currentFrame.Rolls.Count == ALLOWED_ROLLS || tenthFrameBonusRoll)
                {
                    if (spare)
                    {
                        currentFrame.Bonus = Rolls.ElementAtOrDefault(roll.index + 1);//Next roll counts as bonus
                    }
                    else if (strike)
                    {
                        currentFrame.Bonus = Rolls.ElementAtOrDefault(roll.index + 1) + Rolls.ElementAtOrDefault(roll.index + 2);//Next two rolls count as bonus
                    }

                    //Finish Frame
                    if (!tenthFrameBonusRoll)
                    {
                        Frames.Add(currentFrame);
                        currentFrame = new Frame();
                    }
                }
            }

            //Total Finished Frames
            Frames.ForEach(f => finalScore += f.Score);

            //Unfinished Game
            if (Frames.Count < ALLOWED_FRAMES)
            {
                finalScore += currentFrame.Score;
            }

            return finalScore;
        }
    }
}
