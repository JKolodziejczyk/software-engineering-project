using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.models
{
    public abstract class Item
    {
        protected int _id { get; set; }
        protected int[] _stats { get; set; }
        protected string _name { get; set; }
        protected int _owner { get; set; }
        protected int _type { get; set; }

        public int owner { get { return _owner; } }
        public int type { get { return _type; } }
        public int id { get { return _id; } }
        public int[] stats { get { return _stats; } }
        public string name { get { return _name; } }

        public string getType()
        {
            if (_type == 1) return "Broń";
            else if (_type == 2) return "Pancerz";
            else return "Szczęśliwy";
        }

        public string getStats()
        {
            return $"A: {_stats[0]} O: {_stats[1]} S: {_stats[2]}";
        }
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

        public Weapon(ItemBase item)
        {
            _id = item.id;
            _stats = item.stats;
            _name = item.name;
            _owner = item.owner;
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
        public Armor(ItemBase item)
        {
            _id = item.id;
            _stats = item.stats;
            _name = item.name;
            _owner = item.owner;
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
        public Lucky(ItemBase item)
        {
            _id = item.id;
            _stats = item.stats;
            _name = item.name;
            _owner = item.owner;
            _type = 3;
        }
    }
}
