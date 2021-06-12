using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.models
{
    public class Buff
    {
        public int id { get; }
        public string name { get; }
        public int[] stats { get; }
        private int _remaining_time { get; set; }

        public int remaining_time()
        {
            return _remaining_time;
        }

        public int decrement_time()
        {
            _remaining_time--;
            return _remaining_time;
        }

        public string getStats()
        {
            string[] statsNames = { "A", "O", "S", "Z", "E", "P", "ZŁ" };
            string res = "";
            for(int i = 0; i < stats.Length; i++)
            {
                if(stats[i] != 0)
                {
                    res += $"{statsNames[i]}: {stats[i]} ";
                }
            }
            res += $"czas: {_remaining_time}";
            return res;
        }

        public Buff(BuffBase buff, int remaining_time)
        {
            id = buff.id;
            name = buff.name;
            stats = buff.stats;
            this._remaining_time = remaining_time;
        }
    }
}
