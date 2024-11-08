using GameOff2024.Game.Data.Entity;

namespace GameOff2024.Game.Domain.UseCase
{
    public sealed class ChipUseCase
    {
        private readonly ChipEntity _chipEntity;

        public ChipUseCase(ChipEntity chipEntity)
        {
            _chipEntity = chipEntity;
        }

        public void Add(int value)
        {
            _chipEntity.Add(value);
        }
    }
}