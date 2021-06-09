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
        public float[] statsWin { get; }
        public float[] statsLose { get; }
        public int[] buffsWin { get; }
        public int[] buffsLose { get; }
        public bool[] flags { get; }
        public bool item { get; }

        public ChoiceBase(string desc, float chance, string win, string lose, float[] statsWin, float[] statsLose, int[] buffsWin, int[] buffsLose, bool[] flags, bool item)
        {
            this.desc = desc;
            this.chance = chance;
            this.win = win;
            this.lose = lose;
            this.statsWin = statsWin;
            this.statsLose = statsLose;
            this.buffsWin = buffsWin;
            this.buffsLose = buffsLose;
            this.item = item;
        }
    }
}
