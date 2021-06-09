using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.models;

namespace RPG.logic_layer
{
    public class EventBuilder
    {
        static EventBuilder _instance;
        Location[] locations { get; set; }
        Event[] events { get; set; }

        private EventBuilder() { }

        public static EventBuilder instance
        {
            get
            {
                if(instance == null)
                {
                    _instance = new EventBuilder();
                }
                return _instance;
            }
        }

        public void setLocations(Location[] locations)
        {
            this.locations = locations;
        }

        public void setEvents(Event[] events)
        {
            this.events = events;
        }
    }
}
