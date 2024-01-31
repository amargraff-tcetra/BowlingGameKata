using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BowlingGameKata.Models
{
    public class Game
    {
        private static readonly int PIN_COUNT = 10;
        private static readonly int ALLOWED_ROLLS = 2;
        private static readonly int ALLOWED_FRAMES = 10;
        public List<Roll> Rolls { get; set; }= new List<Roll>();
        public List<Frame> CompletedFrames { get; set; } = new List<Frame>();

        public void Roll(int pins)
        {
            if (CompletedFrames.Count < ALLOWED_FRAMES)
            {
                Rolls.Add(new Roll(index: Rolls.Count, value: pins));
            }
            //Running Score
            _ = Score();
        }

        public int Score()
        {
            //Reset
            CompletedFrames = new List<Frame>();
            var currentFrame = new Frame(1);
            var finalScore = 0;

            foreach(var roll in Rolls)
            {
                currentFrame.Rolls.Add(roll);

                //Frame complete
                if (currentFrame.IsComplete())
                {
                    CalculateBonus(currentFrame);
                    CompletedFrames.Add(currentFrame);
                    currentFrame = new Frame(CompletedFrames.Count + 1);
                }
            }

            CompletedFrames.ForEach(f => finalScore += f.Score);
            return finalScore += currentFrame.Score;
        }

        private void CalculateBonus(Frame frame)
        {
            if (frame.Rolls.Count >= ALLOWED_ROLLS && frame.Rolls.Take(2).Sum() == PIN_COUNT)//Spare
            {
                frame.Bonus = Rolls.ElementValueAtOrDefault(frame.Rolls[1].Index + 1);//Next roll counts as bonus
            }
            else if (frame.Rolls.Count == 1 && frame.Rolls.Sum() == PIN_COUNT)//Strike
            {
                frame.Bonus = Rolls.ElementValueAtOrDefault(frame.Rolls[0].Index + 1) + Rolls.ElementValueAtOrDefault(frame.Rolls[0].Index + 2);//Next two rolls count as bonus
            }
        }
    }
}
