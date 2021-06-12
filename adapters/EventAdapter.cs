using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using RPG.models;

namespace RPG.logic_layer
{
    class EventAdapter
    {
        static readonly string directory= new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.Parent.FullName;
        readonly string PATH = Path.Combine(directory, @"entities\events.json");
        readonly EventBuilder eventBuilder;

        public EventAdapter(EventBuilder eventBuilder)
        {
            this.eventBuilder = eventBuilder;
        }

        public void readData()
        {
            StreamReader file = File.OpenText(PATH);
            EventBase[] events = JsonSerializer.Deserialize<EventBase[]>(file.ReadToEnd());
            eventBuilder.setEvents(events);
        }
    }
}
