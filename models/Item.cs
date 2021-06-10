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

    }

    public class Weapon: Item
    {
        public int id { get { return _id; } }
        public int[] stats { get { return _stats; } }
        public string name { get { return _name; } }
        public Weapon(int id, int[] stats, string name)
        {
            _id = id;
            _stats = stats;
            _name = name;
        }
    }

    public class Armor : Item 
    {
        public int id { get { return _id; } }
        public int[] stats { get { return _stats; } }
        public string name { get { return _name; } }
        public Armor(int id, int[] stats, string name)
        {
            _id = id;
            _stats = stats;
            _name = name;
        }
    }

    public class Lucky : Item 
    {
        public int id { get { return _id; } }
        public int[] stats { get { return _stats; } }
        public string name { get { return _name; } }
        public Lucky(int id, int[] stats, string name)
        {
            _id = id;
            _stats = stats;
            _name = name;
        }
    }
}
