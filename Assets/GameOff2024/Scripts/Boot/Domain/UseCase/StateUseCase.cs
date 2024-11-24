using R3;

namespace GameOff2024.Boot.Domain.UseCase
{
    public sealed class StateUseCase
    {
        private readonly Subject<BootState> _state;

        public StateUseCase()
        {
            _state = new Subject<BootState>();
        }

        public Observable<BootState> state => _state.Where(x => x != BootState.None);

        public void Set(BootState value) => _state?.OnNext(value);
    }
}