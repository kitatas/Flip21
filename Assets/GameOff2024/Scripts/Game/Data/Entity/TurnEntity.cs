namespace GameOff2024.Game.Data.Entity
{
    public sealed class TurnEntity
    {
        public int count { get; private set; }

        public TurnEntity()
        {
            Reset();
        }

        public void Increment() => count++;
        public void Set(int value) => count = value;
        public void Reset() => Set(0);
    }
}