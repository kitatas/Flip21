using GameOff2024.Game.Data.Entity;
using R3;

namespace GameOff2024.Game.Domain.UseCase
{
    public sealed class BetUseCase
    {
        private readonly ChipEntity _chipEntity;
        private readonly ReactiveProperty<int> _bet;

        public BetUseCase(ChipEntity chipEntity)
        {
            _chipEntity = chipEntity;
            _bet = new ReactiveProperty<int>(0);
        }

        public Observable<int> bet => _bet;
        public Observable<bool> isPlus => _bet.Select(x => x < _chipEntity.current);
        public Observable<bool> isMinus => _bet.Select(x => x > 0);

        public void Add(int value) => _bet.Value += value;
    }
}