using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.models
{
    public class Location
    {
        public int id { get; }
        public string name { get; }
        public string desc { get; }
        public string next_event { get; }

        public Location(int id, string name, string desc, string next_event)
        {
            this.id = id;
            this.name = name;
            this.desc = desc;
            this.next_event = next_event;
        }

    }
}
