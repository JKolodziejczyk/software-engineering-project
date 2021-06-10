using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.models
{
    public class BuffBase
    {
        public int id { get; }
        public string name { get; }
        public int[] stats { get; }
        public BuffBase(int id, string name, int[] stats)
        {
            this.id = id;
            this.name = name;
            this.stats = stats;
        }
    }
}
