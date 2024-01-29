using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGameKata.Models
{
    public class Frame
    {
        public List<int> Rolls { get; set; } = new List<int>();
        public int Score { get => Rolls.Sum(); }
    }
}
