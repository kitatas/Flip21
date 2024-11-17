using System.Collections.Generic;

namespace GameOff2024.Game.Data.Entity
{
    public abstract class HandEntity
    {
        public readonly List<int> hands;

        public HandEntity()
        {
            hands = new List<int>();
        }

        public void Add(int value)
        {
            hands.Add(value);
        }

        public void Clear() => hands.Clear();
    }
}