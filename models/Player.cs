namespace RPG.models
{
    public abstract class Player
    {
        string rank { get; }
        protected int rank_id { get; set; }
        int[] stats { get; }
        private Item item1 { get; set; }
        private Item item2 { get; set; }
        private Item item3 { get; set; }

        private void Change_stat(int statType, int value)
        {
            
        }
    }

    public class Berserker : Player
    {
        Weapon item1 { get; set; }
        Weapon item2 { get; set; }
        Lucky item3 { get; set; }
        
    }

    public class Knight : Player
    {
        Weapon item1 { get; set; }
        Armor item2 { get; set; }
        Lucky item3 { get; set; }
    }

    public class Thief : Player
    {
        Weapon item1 { get; set; }
        Lucky item2 { get; set; }
        Lucky item3 { get; set; }

    }
    
}