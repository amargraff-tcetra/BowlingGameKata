using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGameKata.Models
{
    public class Roll
    {
        public int Index { get; set; }
        public int Value { get; set; }

        public Roll(int index, int value)
        {
            Index = index;
            Value = value;
        }
    }

    public static class Extensions
    {
        public static int Sum(this IEnumerable<Roll> rolls)
        {
            return rolls.Select(r => r.Value).Sum();
        }

        public static int ElementValueAtOrDefault(this IEnumerable<Roll> rolls, int index)
        {
            return rolls.ElementAtOrDefault(index)?.Value ?? 0;
        }
    }
}
