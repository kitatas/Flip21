using UnityEngine;

namespace GameOff2024.Game.Data.Entity
{
    public sealed class ChipEntity
    {
        private int _value;

        public ChipEntity()
        {
            _value = ChipConfig.INIT_VALUE;
        }

        public int current => _value;

        public void Add(int value) => _value = Mathf.Max(_value + value, 0);
    }
}