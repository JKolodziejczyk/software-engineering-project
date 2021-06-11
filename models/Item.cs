using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.models
{
    public abstract class Item
    {
        public int _id { get; set; }
        public int[] _stats { get; set; }
        public string _name { get; set; }
        public int _owner { get; set; }
        
        public int _type { get; set; }

    }

    public class Weapon: Item
    {
        public Weapon(int id, int[] stats, string name, int owner)
        {
            _id = id;
            _stats = stats;
            _name = name;
            _owner = owner;
            _type = 1;
        }
    }

    public class Armor : Item 
    {
        public Armor(int id, int[] stats, string name, int owner)
        {
            _id = id;
            _stats = stats;
            _name = name;
            _owner = owner;
            _type = 2;
        }
    }

    public class Lucky : Item 
    {
        public Lucky(int id, int[] stats, string name, int owner)
        {
            _id = id;
            _stats = stats;
            _name = name;
            _owner = owner;
            _type = 3;
        }
    }
}
