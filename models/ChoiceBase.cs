using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.models
{
    public class ChoiceBase
    {
        public string desc { get; }
        public float chance { get; }
        public string win { get; }
        public string lose { get; }
        public float[] stats { get; }
        public int buff { get; }
        public bool item { get; }

        public ChoiceBase(string desc, float chance, string win, string lose, float[] stats, int buff, bool item)
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
