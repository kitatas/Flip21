using GameOff2024.Game.Domain.UseCase;
using GameOff2024.Game.Presentation.View;
using R3;
using VContainer.Unity;

namespace GameOff2024.Game.Presentation.Presenter
{
    public sealed class BetPresenter : IStartable
    {
        private readonly BetUseCase _betUseCase;
        private readonly BetView _betView;

        public BetPresenter(BetUseCase betUseCase, BetView betView)
        {
            _betUseCase = betUseCase;
            _betView = betView;
        }

        public void Start()
        {
            _betUseCase.bet
                .Subscribe(_betView.Render)
                .AddTo(_betView);

            _betView.bet
                .Subscribe(_betUseCase.Add)
                .AddTo(_betView);

            _betView.Init();
        }
    }
}