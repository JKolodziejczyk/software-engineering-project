using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.models
{
    public class Event
    {
        string desc { get; }
        Location location { get; }
        Choice[] choices { get; }

        Event(string desc, Location location, Choice[] choices)
        {
            this.desc = desc;
            this.location = location;
            this.choices = choices;
        }
    }
}
