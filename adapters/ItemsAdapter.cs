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
    class ItemsAdapter
    {
        static readonly string directory= new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.Parent.FullName;
        readonly string PATH = Path.Combine(directory, @"entities\items.json");
        readonly EventBuilder eventBuilder;

        public ItemsAdapter(EventBuilder eventBuilder)
        {
            this.eventBuilder = eventBuilder;
        }
        public void readData()
        {
            StreamReader file = File.OpenText(PATH); 
            ItemBase[] itemsbase = JsonSerializer.Deserialize<ItemBase[]>(file.ReadToEnd());
            List<Item> items = new();
            foreach (ItemBase _item in itemsbase)
            {
                if (_item.type == 1)
                {
                    items.Add(new Weapon(_item));
                }
                if (_item.type == 2)
                {
                    items.Add(new Armor(_item));
                }
                if (_item.type == 3)
                {
                    items.Add(new Lucky(_item));
                }
            }
            eventBuilder.setItems(items.ToArray());
        }
    }
}
