using R3;

namespace GameOff2024.Game.Domain.UseCase
{
    public sealed class StateUseCase
    {
        private readonly ReactiveProperty<GameState> _state;

        public StateUseCase()
        {
            _state = new ReactiveProperty<GameState>(GameState.None);
        }

        public Observable<GameState> state => _state.Where(x => x != GameState.None);

        public void Set(GameState value) => _state.Value = value;
    }
}