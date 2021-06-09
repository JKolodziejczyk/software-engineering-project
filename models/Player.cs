namespace RPG.models
{
    public class Player
    {
        string rank { get; }
        protected int rank_id { get; set; }
        int[] stats { get; }

        private void Change_stat(int statType, int value)
        {
            
        }
    }

    public class Berserker : Player
    {
        private Weapon[] _weapons { get; set; }
        private Lucky _lucky { get; set; }

        public Berserker()
        {
            this.rank_id=1;
        }
    }

    public class Knight : Player
    {
        private Weapon _weapon { get; set; }
        private Armor _armor { get; set; }
        private Lucky _lucky { get; set; }

        public Knight()
        {
            this.rank_id = 2;
        }
    }

    public class Thief : Player
    {
        private Weapon _weapon { get; set; }
        private Lucky[] _luckies { get; set; }

        public Thief()
        {
            this.rank_id = 3;
        }
    }
    
}