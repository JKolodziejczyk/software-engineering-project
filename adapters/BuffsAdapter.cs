﻿using System;
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
        static readonly string directory= new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.Parent.FullName;
        readonly string PATH = Path.Combine(directory, @"entities\buffs.json");
        readonly EventBuilder eventBuilder;

        public BuffsAdapter(EventBuilder eventBuilder)
        {
            this.eventBuilder = eventBuilder;
        }

        public void readData()
        {
            StreamReader file = File.OpenText(PATH);
            BuffBase[] buffs = JsonSerializer.Deserialize<BuffBase[]>(file.ReadToEnd());
            eventBuilder.setBuffs(buffs);
        }
    }
}
