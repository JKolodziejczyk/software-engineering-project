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
        protected List<Buff> _buffs { get; set; }

        public int classId { get { return _class_id; } }
        public void changeStats(int[] diff)
        {
            for(int i = 0; i < diff.Length; i++)
            {
                stats[i] += diff[i];
            }
            stats_min_max();
        }

        public int is_dead()
        {
            if (stats[3] <= 0) return 1;
            if (stats[4] <= 0) return 2;
            if (stats[5] <= 0) return 3;
            return 0;
        }

        public void addBuffs(Buff[] buffs)
        {
            foreach(Buff buff in buffs)
            {
                _buffs.Add(buff);
            }
        }

        protected abstract void stats_min_max();

        public string getClass()
        {
            return _class;
        }

        private void Expiring_buffs()
        {
            for (var i = 0; i < this._buffs.Count; i++)
            {
                if (_buffs[i].remaining_time() <= 0)
                {
                    _buffs.RemoveAt(i);
                    i--;
                }
            }
        }

        public void apply_buffs()
        {
            foreach (var elem in _buffs)
            {
                for (int i = 0; i < 6; i++) stats[i] += elem.stats[i];
                elem.decrement_time();
            }
            Expiring_buffs();
            stats_min_max();
        }

        public abstract void Change_item(Item new_item, int which_slot);

        public int[] getStats()
        {
            var Current = new int[stats.Length];
            for (var i = 0; i < stats.Length; i++)
            {
                Current[i] = stats[i];
            }
            if (item1 != null)
            {
                for (var i = 0; i < 3; i++) Current[i] += item1.stats[i];
            }
            if (item2 != null)
            {
                for (var i = 0; i < 3; i++) Current[i] += item2.stats[i];
            }
            if (item3 != null)
            {
                for (var i = 0; i < 3; i++) Current[i] += item3.stats[i];
            }
            return Current;
        }

        public abstract Item[] getItems();

        public abstract string[] getSlotTypesName();

        public abstract int[] getSlotTypes();

        public Buff[] getBuffs()
        {
            return _buffs.ToArray();
        }

    }

    public class Berserker : Player
    {
        private Weapon item1 { get; set; }
        private Weapon item2 { get; set; }
        private Lucky item3 { get; set; }
        public Berserker()
        {
            Random statrandomizer = new Random();
            item1 = null;
            item2 = null;
            item3 = null;
            _class = "Berserker";
            _class_id = 1;
            stats = new int[] {25, 15, 20, statrandomizer.Next(80,100),statrandomizer.Next(60,100),statrandomizer.Next(50,100), 0};
            _buffs = new();
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

        public override string[] getSlotTypesName()
        {
            string[] res = { "Broń", "Broń", "Szczęśliwe" };
            return res;
        }

        public override int[] getSlotTypes()
        {
            int[] res = { 1, 1, 3 };
            return res;
        }

        public override Item[] getItems()
        {
            Item[] res = new Item[3];
            res[0] = item1;
            res[1] = item2;
            res[2] = item3;
            return res;
        }

        public override void Change_item(Item new_item, int which_slot)
        {
            switch (which_slot)
            {
                case 0:
                {
                    if (new_item is Weapon item)
                    {
                        item1 =item;
                    }
                        break;
                }
                case 1:
                {
                    if (new_item is Weapon item)
                    {
                        item2=item;
                    }
                        break;
                }
                case 2:
                {
                    if (new_item is Lucky item)
                    {
                        item3=item;
                    }
                        break;
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
            Random statrandomizer = new Random();
            item1 = null;
            item2 = null;
            item3 = null;
            _class = "Rycerz";
            _class_id = 2;
            stats = new int[] {20, 20, 20, statrandomizer.Next(80,100), statrandomizer.Next(60,100), statrandomizer.Next(50,100), 0};
            _buffs = new();
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

        public override Item[] getItems()
        {
            Item[] res = new Item[3];
            res[0] = item1;
            res[1] = item2;
            res[2] = item3;
            return res;
        }

        public override string[] getSlotTypesName()
        {
            string[] res = { "Broń", "Pancerz", "Szczęśliwe" };
            return res;
        }

        public override int[] getSlotTypes()
        {
            int[] res = { 1, 2, 3 };
            return res;
        }

        public override void Change_item(Item new_item, int which_slot)
        {
            switch (which_slot)
            {
                case 0:
                    {
                        if (new_item is Weapon item)
                        {
                            item1 = item;
                        }
                        break;
                    }
                case 1:
                    {
                        if (new_item is Armor item)
                        {
                            item2 = item;
                        }
                        break;
                    }
                case 2:
                    {
                        if (new_item is Lucky item)
                        {
                            item3 = item;
                        }
                        break;
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
            Random statrandomizer = new Random();
            item1 = null;
            item2 = null;
            item3 = null;
            _class = "Złodziej";
            _class_id = 3;
            stats = new int[] {20, 15, 25, statrandomizer.Next(80,100),statrandomizer.Next(60,100),statrandomizer.Next(50,100),0};
            _buffs = new();
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

        public override string[] getSlotTypesName()
        {
            string[] res = { "Broń", "Szczęśliwe", "Szczęśliwe" };
            return res;
        }

        public override Item[] getItems()
        {
            Item[] res = new Item[3];
            res[0] = item1;
            res[1] = item2;
            res[2] = item3;
            return res;
        }

        public override int[] getSlotTypes()
        {
            int[] res = { 1, 3, 3 };
            return res;
        }

        public override void Change_item(Item new_item, int which_slot)
        {
            switch (which_slot)
            {
                case 0:
                    {
                        if (new_item is Weapon item)
                        {
                            item1 = item;
                        }
                        break;
                    }
                case 1:
                    {
                        if (new_item is Lucky item)
                        {
                            item2 = item;
                        }
                        break;
                    }
                case 2:
                    {
                        if (new_item is Lucky item)
                        {
                            item3 = item;
                        }
                        break;
                    }
            }
        }
    }

}
