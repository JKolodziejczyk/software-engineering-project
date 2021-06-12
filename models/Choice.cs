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
        public int[] statsWin { get; }
        public int[] statsLose { get; }
        public Buff[] buffsWin { get; }
        public Buff[] buffsLose { get; }
        public float[] flags { get; }
        public Item item { get; }

        public Choice(string desc, float chance, string win, string lose, int[] statsWin, int[] statsLose, Buff[] buffsWin, Buff[] buffsLose, float[] flags, Item item)
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
