using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.models
{
    public class Choice
    {
        string desc { get; }
        float chance { get; }
        string win { get; }
        string lose { get; }
        float[] stats { get; }
        int buff { get; }
        int item { get; }

        Choice(string desc, float chance, string win, string lose, float[] stats, int buff, int item)
        {
            this.desc = desc;
            this.chance = chance;
            this.win = win;
            this.lose = lose;
            this.stats = stats;
            this.buff = buff;
            this.item = item;
        }
    }
}
