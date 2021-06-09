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
    class BuffsAdapter
    {
        readonly string PATH = @"";
        readonly EventBuilder eventBuilder;

        public BuffsAdapter(EventBuilder eventBuilder)
        {
            this.eventBuilder = eventBuilder;
        }

        public void readData()
        {
            StreamReader file = File.OpenText(PATH);
            Buff[] buffs = JsonSerializer.Deserialize<Buff[]>(file.ReadToEnd());
            eventBuilder.setBuffs(buffs);
        }
    }
}
