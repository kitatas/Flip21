using R3;

namespace GameOff2024.Game.Domain.UseCase
{
    public sealed class ModalUseCase
    {
        private readonly ReactiveProperty<GameModal> _gameModal;

        public ModalUseCase()
        {
            _gameModal = new ReactiveProperty<GameModal>(GameModal.None);
        }

        public Observable<GameModal> gameModal => _gameModal.Where(x => x != GameModal.None);

        public void SetUp(GameModal value) => _gameModal.Value = value;
    }
}