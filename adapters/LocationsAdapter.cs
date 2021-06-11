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
    public class LocationsAdapter
    {
        static readonly string directory= new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.Parent.FullName;
        readonly string PATH = Path.Combine(directory, @"entities\locations.json");
        readonly EventBuilder eventBuilder;

        public LocationsAdapter(EventBuilder eventBuilder)
        {
            this.eventBuilder = eventBuilder;
        }
        
        public void readData()
        {
            StreamReader file = File.OpenText(PATH);
            Location[] locations = JsonSerializer.Deserialize<Location[]>(file.ReadToEnd());
            eventBuilder.setLocations(locations);
        }
    }
}
