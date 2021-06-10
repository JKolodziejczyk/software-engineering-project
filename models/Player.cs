using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RPG.models
{
    public abstract class Player
    {
        protected string _class { get; init; }
        protected int _class_id { get; init; }
        protected int[] stats { get; set; }
        private Item item1 { get; set; }
        private Item item2 { get; set; }
        private Item item3 { get; set; }
        private List<Buff> _buffs { get; set; }

        public void Change_stat(int stat_type, int value)
        {
            stats[stat_type] += value;
            stats_min_max();
        }


        public void add_buff(Buff buff)
        {
            _buffs.Add(buff);
        }

        protected abstract void stats_min_max();
        private void Expiring_buffs()
        {
            for (var i=0; i<this._buffs.Count; i++)
            {
                if (_buffs[i].remaining_time() <= 0) _buffs.RemoveAt(i);
                else _buffs[i].decrement_time();
            }
        }

        private void apply_buffs()
        {
            foreach (var elem in _buffs)
            {
                for (var i = 0; i < 6; i++) stats[i] += elem.stats[i];
            }
        }

        public void end_event()
        {
            Expiring_buffs();
            apply_buffs();
        }
        public abstract bool Change_item(Item new_item, int which_slot);

        public int[] DisplayStats()
        {
            var Current = new int[7];
            for (var i = 0; i < 7; i++)
            {
                Current[i] = this.stats[i];
            }
            if (item1 != null)
            {
                for (var i = 0; i < 3; i++) Current[i] += item1._stats[i];
            }
            if (item2 != null)
            {
                for (var i = 0; i < 3; i++) Current[i] += item2._stats[i];
            }
            if (item3 != null)
            {
                for (var i = 0; i < 3; i++) Current[i] += item3._stats[i];
            }
            /*
            Console.WriteLine("Atak: ",Current[0]);
            Console.WriteLine("Obrona: ",Current[1]);
            Console.WriteLine("Szczęście: ",Current[2]);
            Console.WriteLine("HP: ",Current[3]);
            Console.WriteLine("Energia: ",Current[4]);
            Console.WriteLine("Psycha: ",Current[5]);
            Console.WriteLine("Złoto: ",Current[6]);*/
            return Current;
        }
    }

    public class Berserker : Player
    {
        private Weapon item1 { get; set; }
        private Weapon item2 { get; set; }
        private Lucky item3 { get; set; }
        public Berserker()
        {
            item1 = null;
            item2 = null;
            item3 = null;
            _class = "Berserker";
            _class_id = 1;
        }

        protected override void stats_min_max()
        {
            if (stats[0] > 65) stats[0] = 65;
            if (stats[1] > 35) stats[1] = 35;
            if (stats[2] > 50) stats[2] = 50;
            if (stats[3] > 100) stats[3] = 100;
            if (stats[4] > 100) stats[4] = 100;
            if (stats[5] > 100) stats[5] = 100;
            if (stats[0] < 0) stats[0] = 0;
            if (stats[1] < 0) stats[1] = 0;
            if (stats[2] < 0) stats[2] = 0;
            if (stats[3] < 0) stats[3] = 0;
            if (stats[4] < 0) stats[4] = 0;
            if (stats[5] < 0) stats[5] = 0;
            if (stats[6] < 0) stats[6] = 0;
        }
        public override bool Change_item(Item new_item, int which_slot)
        {
            switch (which_slot)
            {
                case 1:
                {
                    if (new_item is Weapon item) 
                    {
                        item1 =item;
                        return true;
                    }
                    Console.WriteLine("Wybrałeś zły slot");
                    return false;
                }
                case 2:
                {
                    if (new_item is Weapon item)
                    {
                        item2=item;
                        return true;
                    }
                    Console.WriteLine("Wybrałeś zły slot");
                    return false;
                }
                case 3:
                {
                    if (new_item is Lucky item)
                    {
                        item3=item;
                        return true;
                    }
                    Console.WriteLine("Wybrałeś zły slot");
                    return false;
                }
                case 0:
                    return true;
                default:
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }

    public class Knight : Player
    {
        private Weapon item1 { get; set; }
        private Armor item2 { get; set; }
        private Lucky item3 { get; set; }

        public Knight()
        {
            item1 = null;
            item2 = null;
            item3 = null;
            _class = "Knight";
            _class_id = 2;
        }

        protected override void stats_min_max()
        {
            if (stats[0] > 50) stats[0] = 50;
            if (stats[1] > 50) stats[1] = 50;
            if (stats[2] > 50) stats[2] = 50;
            if (stats[3] > 100) stats[3] = 100;
            if (stats[4] > 100) stats[4] = 100;
            if (stats[5] > 100) stats[5] = 100;
            if (stats[0] < 0) stats[0] = 0;
            if (stats[1] < 0) stats[1] = 0;
            if (stats[2] < 0) stats[2] = 0;
            if (stats[3] < 0) stats[3] = 0;
            if (stats[4] < 0) stats[4] = 0;
            if (stats[5] < 0) stats[5] = 0;
            if (stats[6] < 0) stats[6] = 0;
        }

        public override bool Change_item(Item new_item, int which_slot)
        {
            switch (which_slot)
            {
                case 1:
                {
                    if (new_item is Weapon item) 
                    {
                        item1 =item;
                        return true;
                    }
                    Console.WriteLine("Wybrałeś zły slot");
                    return false;
                }
                case 2:
                {
                    if (new_item is Armor item)
                    {
                        item2=item;
                        return true;
                    }
                    Console.WriteLine("Wybrałeś zły slot");
                    return false;
                }
                case 3:
                {
                    if (new_item is Lucky item)
                    {
                        item3=item;
                        return true;
                    }
                    Console.WriteLine("Wybrałeś zły slot");
                    return false;
                }
                case 0:
                    return true;
                default:
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }

    public class Thief : Player
    {
        private Weapon item1 { get; set; }
        private Lucky item2 { get; set; }
        private Lucky item3 { get; set; }
        public Thief()
        {
            item1 = null;
            item2 = null;
            item3 = null;
            _class = "Thief";
            _class_id = 3;
        }

        protected override void stats_min_max()
        {
            if (stats[0] > 50) stats[0] = 50;
            if (stats[1] > 35) stats[1] = 35;
            if (stats[2] > 65) stats[2] = 65;
            if (stats[3] > 100) stats[3] = 100;
            if (stats[4] > 100) stats[4] = 100;
            if (stats[5] > 100) stats[5] = 100;
            if (stats[0] < 0) stats[0] = 0;
            if (stats[1] < 0) stats[1] = 0;
            if (stats[2] < 0) stats[2] = 0;
            if (stats[3] < 0) stats[3] = 0;
            if (stats[4] < 0) stats[4] = 0;
            if (stats[5] < 0) stats[5] = 0;
            if (stats[6] < 0) stats[6] = 0;
        }
        public override bool Change_item(Item new_item, int which_slot)
        {
            switch (which_slot)
            {
                case 1:
                {
                    if (new_item is Weapon item) 
                    {
                        item1 =item;
                        return true;
                    }
                    Console.WriteLine("Wybrałeś zły slot");
                    return false;
                }
                case 2:
                {
                    if (new_item is Lucky item)
                    {
                        item2=item;
                        return true;
                    }
                    Console.WriteLine("Wybrałeś zły slot");
                    return false;
                }
                case 3:
                {
                    if (new_item is Lucky item)
                    {
                        item3=item;
                        return true;
                    }
                    Console.WriteLine("Wybrałeś zły slot");
                    return false;
                }
                case 0:
                    return true;
                default:
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
    
}