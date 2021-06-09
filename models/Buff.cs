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
        public int time { get; }

        public Buff(int id, string name, int time)
        {
            this.id = id;
            this.name = name;
            this.time = time;
        }
    }
}
