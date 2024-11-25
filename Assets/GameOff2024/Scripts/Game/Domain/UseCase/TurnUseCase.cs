using R3;

namespace GameOff2024.Game.Domain.UseCase
{
    public sealed class TurnUseCase
    {
        private readonly ReactiveProperty<int> _turn;

        public TurnUseCase()
        {
            _turn = new ReactiveProperty<int>(0);
        }

        public Observable<int> turn => _turn;

        public void Increment()
        {
            _turn.Value++;
        }
    }
}