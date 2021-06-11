namespace RPG.models
{
    public class ItemBase
    {
        public int id { get; }
        public int[] stats { get; }
        public string name { get; }
        public int type { get; }
        public int owner { get; }
        
        public ItemBase(int id, int[] stats, string name, int type, int owner)
        {
            this.id = id;
            this.stats = stats;
            this.name = name;
            this.type = type;
            this.owner = owner;
        }
    }
    
}