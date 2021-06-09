using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.models
{
   public class EventBase
    {
        int id { get; }
        string desc { get; }
        int[] locations { get; }
        Choice[] choices { get; }

        EventBase(int id, string desc, int[] locations, Choice[] choices)
        {
            this.id = id;
            this.desc = desc;
            this.locations = locations;
            this.choices = choices;
        }
    }
}
