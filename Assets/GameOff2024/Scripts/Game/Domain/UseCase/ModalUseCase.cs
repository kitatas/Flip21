using R3;

namespace GameOff2024.Game.Domain.UseCase
{
    public sealed class ModalUseCase
    {
        private readonly Subject<GameModal> _setup;

        public ModalUseCase()
        {
            _setup = new Subject<GameModal>();
        }

        public Observable<GameModal> setup => _setup.Where(x => x != GameModal.None);

        public void SetUp(GameModal value) => _setup?.OnNext(value);
    }
}