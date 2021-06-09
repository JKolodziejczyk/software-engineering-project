using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.models
{
    public class Item
    {
        int[] stats { get; set; }
    }

    class Weapon: Item
    {
    }

    class Armor : Item { }

    class Lucky : Item { }
}
