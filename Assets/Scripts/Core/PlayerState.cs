namespace Game.Core
{
    public struct PlayerState
    {
        public PlayerState(bool isAlive)
        {
            this.isAlive = isAlive;
        }

        public bool isAlive;
    }
}