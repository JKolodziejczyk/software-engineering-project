using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.models
{
    public class Location
    {
        int id { get; }
        string name { get; }
        string desc { get; }
        string next_event { get; }

        Location(int id, string name, string desc, string next_event)
        {
            this.id = id;
            this.name = name;
            this.desc = desc;
            this.next_event = next_event;
        }

    }
}
