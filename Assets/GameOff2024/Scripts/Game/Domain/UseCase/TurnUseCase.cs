using GameOff2024.Game.Data.Entity;
using R3;

namespace GameOff2024.Game.Domain.UseCase
{
    public sealed class TurnUseCase
    {
        private readonly TurnEntity _turnEntity;
        private readonly ReactiveProperty<int> _turn;

        public TurnUseCase(TurnEntity turnEntity)
        {
            _turnEntity = turnEntity;
            _turn = new ReactiveProperty<int>(_turnEntity.count);
        }

        public Observable<int> turn => _turn;

        public void Increment()
        {
            _turnEntity.Increment();
            _turn.Value = _turnEntity.count;
        }
    }
}