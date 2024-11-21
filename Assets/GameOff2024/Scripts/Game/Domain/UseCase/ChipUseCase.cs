using GameOff2024.Game.Data.Entity;
using R3;
using UnityEngine;

namespace GameOff2024.Game.Domain.UseCase
{
    public sealed class ChipUseCase
    {
        private readonly ChipEntity _chipEntity;
        private readonly ReactiveProperty<int> _chip;

        public ChipUseCase(ChipEntity chipEntity)
        {
            _chipEntity = chipEntity;
            _chip = new ReactiveProperty<int>(_chipEntity.current);
        }

        public Observable<int> chip => _chip;
        public int current => _chip.Value;

        public void Add(float value)
        {
            Add(Mathf.CeilToInt(value));
        }

        public void Add(int value)
        {
            _chipEntity.Add(value);
            _chip.Value = _chipEntity.current;
        }

        public void Bet(int value) => Add(-value);
    }
}