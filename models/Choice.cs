using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.models
{
    public class Choice
    {
        public string desc { get; }
        public float chance { get; }
        public string win { get; }
        public string lose { get; }
        public float[] statsWin { get; }
        public float[] statsLose { get; }
        public BuffBase buffsWin { get; }
        public BuffBase buffsLose { get; }
        public bool[] flags { get; }
        public Item item { get; }

        public Choice(string desc, float chance, string win, string lose, float[] statsWin, float[] statsLose, BuffBase buffsWin, BuffBase buffsLose, bool[] flags, Item item)
        {
            this.desc = desc;
            this.chance = chance;
            this.win = win;
            this.lose = lose;
            this.statsWin = statsWin;
            this.statsLose = statsLose;
            this.buffsWin = buffsWin;
            this.buffsLose = buffsLose;
            this.flags = flags;
            this.item = item;
        }
    }
}
