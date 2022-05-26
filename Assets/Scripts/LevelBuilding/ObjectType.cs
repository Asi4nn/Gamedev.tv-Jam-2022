namespace Game.LevelBuilding
{
    public enum ObjectType
    {
        Normal, // Interacts with alive players
        Ghost,  // Interacts with dead players
        Hybrid  // Interacts with all players
    }
}