using GameOff2024.Game.Domain.UseCase;
using GameOff2024.Game.Presentation.View;
using R3;
using VContainer.Unity;

namespace GameOff2024.Game.Presentation.Presenter
{
    public sealed class TurnPresenter : IStartable
    {
        private readonly TurnUseCase _turnUseCase;
        private readonly TurnView _turnView;

        public TurnPresenter(TurnUseCase turnUseCase, TurnView turnView)
        {
            _turnUseCase = turnUseCase;
            _turnView = turnView;
        }

        public void Start()
        {
            _turnUseCase.turn
                .Subscribe(_turnView.Render)
                .AddTo(_turnView);
        }
    }
}