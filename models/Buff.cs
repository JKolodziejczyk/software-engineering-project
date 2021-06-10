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
        public int remaining_time { get; }

        public Buff(BuffBase buff, int remaining_time)
        {
            id = buff.id;
            name = buff.name;
            stats = buff.stats;
            this.remaining_time = remaining_time;
        }
    }
}
