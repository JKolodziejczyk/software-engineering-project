using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.models
{
   public class EventBase
    {
        public int id { get; }
        public string desc { get; }
        public int[] locations { get; }
        public Choice[] choices { get; }

        public EventBase(int id, string desc, int[] locations, Choice[] choices)
        {
            this.id = id;
            this.desc = desc;
            this.locations = locations;
            this.choices = choices;
        }
    }
}
