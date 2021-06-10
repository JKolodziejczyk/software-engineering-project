using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.models
{
    public class Event
    {
        public int id { get; }
        public string desc { get; }
        public Location locations { get; }
        public Choice[] choices { get; }

        public Event(int id, string desc, Location location, Choice[] choices)
        {
            this.id = id;
            this.desc = desc;
            this.locations = location;
            this.choices = choices;
        }
    }
}
