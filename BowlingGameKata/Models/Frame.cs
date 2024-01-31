using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BowlingGameKata.Models
{
    public class Frame
    {
        private static readonly int PIN_COUNT = 10;
        private static readonly int ALLOWED_ROLLS = 2;
        private static readonly int ALLOWED_FRAMES = 10;

        public int FrameNumber { get; set; }
        public List<Roll> Rolls { get; set; } = new List<Roll>();
        public int Score { get => Rolls.Sum() + Bonus; }
        public int Bonus { get; set; }

        public Frame(int frameNumber)
        {
            FrameNumber = frameNumber;
        }

        public bool IsComplete()
        {
            if (FrameNumber == ALLOWED_FRAMES)
            {
                return (Rolls.Count == ALLOWED_ROLLS && Rolls.Sum() < PIN_COUNT) || Rolls.Count == ALLOWED_ROLLS + 1;
            }
            else
            {
                return Rolls.Count == ALLOWED_ROLLS || Rolls.Sum() == PIN_COUNT;
            }
        }
    }


}
