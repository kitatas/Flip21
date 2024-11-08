using GameOff2024.Game.Domain.UseCase;
using GameOff2024.Game.Presentation.View;
using R3;
using VContainer.Unity;

namespace GameOff2024.Game.Presentation.Presenter
{
    public sealed class ChipPresenter : IStartable
    {
        private readonly ChipUseCase _chisUseCase;
        private readonly ChipView _chipView;

        public ChipPresenter(ChipUseCase chisUseCase, ChipView chipView)
        {
            _chisUseCase = chisUseCase;
            _chipView = chipView;
        }

        public void Start()
        {
            _chisUseCase.chip
                .Subscribe(_chipView.Render)
                .AddTo(_chipView);
        }
    }
}