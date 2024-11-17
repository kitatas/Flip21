using R3;

namespace GameOff2024.Game.Domain.UseCase
{
    public sealed class StateUseCase
    {
        private readonly Subject<GameState> _state;

        public StateUseCase()
        {
            _state = new Subject<GameState>();
        }

        public Observable<GameState> state => _state.Where(x => x != GameState.None);

        public void Set(GameState value) => _state?.OnNext(value);
    }
}