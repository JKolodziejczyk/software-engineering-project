using System;
using System.Collections.Generic;

namespace RPG.models
{
    public abstract class Player
    {
        public string _class { get; }
        public int _class_id { get; set; }
        int[] stats { get; set; }
        Item item1 { get; set; }
        Item item2 { get; set; }
        Item item3 { get; set; }
        public List<Buff> _buffs { get; set; }

        public void Change_stat(int stat_type, int value)
        {
            this.stats[stat_type]+=value;
        }

        public void add_buff(Buff buff)
        {
            _buffs.Add(buff);
        }

        public void Expiring_buffs()
        {
            for (int i=0; i<this._buffs.Count; i++)
            {
                if (_buffs[i].remaining_time() <= 0) _buffs.RemoveAt(i);
                else _buffs[i].decrement_time();
            }
        }
        public abstract bool Change_item(Item new_item, int which_slot);

        public int[] DisplayStats()
        {
            int[] Current = new int[7];
            Current[0] = this.stats[0];
            Current[1] = this.stats[1];
            Current[2] = this.stats[2];
            Current[3] = this.stats[3];
            Current[4] = this.stats[4];
            Current[5] = this.stats[5];
            Current[6] = this.stats[6];
            foreach (Buff elem in _buffs)
            {
                for (int i = 0; i < 6; i++) Current[i] += elem.stats[i];
            }
            if (item1 != null)
            {
                for (int i = 0; i < 3; i++) Current[i] += item1._stats[i];
            }
            if (item2 != null)
            {
                for (int i = 0; i < 3; i++) Current[i] += item2._stats[i];
            }
            if (item3 != null)
            {
                for (int i = 0; i < 3; i++) Current[i] += item3._stats[i];
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
        Weapon item1 { get; set; }
        Weapon item2 { get; set; }
        Lucky item3 { get; set; }
        public Berserker()
        {
            item1 = null;
            item2 = null;
            item3 = null;
        }
        public override bool Change_item(Item new_item, int which_slot)
        {
            switch (which_slot)
            {
                case 1:
                {
                    if (new_item is Weapon) 
                    {
                        item1 =new_item as Weapon;
                        return true;
                    }
                    else Console.WriteLine("Wybrałeś zły slot");
                    return false;
                }
                case 2:
                {
                    if (new_item is Weapon)
                    {
                        item2=new_item as Weapon;
                        return true;
                    }
                    else Console.WriteLine("Wybrałeś zły slot");
                    return false;
                }
                case 3:
                {
                    if (new_item is Lucky)
                    {
                        item3=new_item as Lucky;
                        return true;
                    }
                    else Console.WriteLine("Wybrałeś zły slot");
                    return false;
                }
                case 0:
                    return true;
            }

            throw new InvalidOperationException();
        }
    }

    public class Knight : Player
    {
        Weapon item1 { get; set; }
        Armor item2 { get; set; }
        Lucky item3 { get; set; }

        public Knight()
        {
            item1 = null;
            item2 = null;
            item3 = null;
        }
        public override bool Change_item(Item new_item, int which_slot)
        {
            switch (which_slot)
            {
                case 1:
                {
                    if (new_item is Weapon) 
                    {
                        item1 =new_item as Weapon;
                        return true;
                    }
                    else Console.WriteLine("Wybrałeś zły slot");
                    return false;
                }
                case 2:
                {
                    if (new_item is Armor)
                    {
                        item2=new_item as Armor;
                        return true;
                    }
                    else Console.WriteLine("Wybrałeś zły slot");
                    return false;
                }
                case 3:
                {
                    if (new_item is Lucky)
                    {
                        item3=new_item as Lucky;
                        return true;
                    }
                    else Console.WriteLine("Wybrałeś zły slot");
                    return false;
                }
                case 0:
                    return true;
            }

            throw new InvalidOperationException();
        }
    }

    public class Thief : Player
    {
        Weapon item1 { get; set; }
        Lucky item2 { get; set; }
        Lucky item3 { get; set; }
        public Thief()
        {
            item1 = null;
            item2 = null;
            item3 = null;
        }
        public override bool Change_item(Item new_item, int which_slot)
        {
            switch (which_slot)
            {
                case 1:
                {
                    if (new_item is Weapon) 
                    {
                        item1 =new_item as Weapon;
                        return true;
                    }
                    else Console.WriteLine("Wybrałeś zły slot");
                    return false;
                }
                case 2:
                {
                    if (new_item is Lucky)
                    {
                        item2=new_item as Lucky;
                        return true;
                    }
                    else Console.WriteLine("Wybrałeś zły slot");
                    return false;
                }
                case 3:
                {
                    if (new_item is Lucky)
                    {
                        item3=new_item as Lucky;
                        return true;
                    }
                    else Console.WriteLine("Wybrałeś zły slot");
                    return false;
                }
                case 0:
                    return true;
            }

            throw new InvalidOperationException();
        }
    }
    
}