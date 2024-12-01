using GameOff2024.Common.Domain.UseCase;
using GameOff2024.Common.Presentation.View;
using R3;
using VContainer.Unity;

namespace GameOff2024.Common.Presentation.Presenter
{
    public sealed class SoundPresenter : IPostInitializable
    {
        private readonly SoundUseCase _soundUseCase;
        private readonly SoundView _soundView;

        public SoundPresenter(SoundUseCase soundUseCase, SoundView soundView)
        {
            _soundUseCase = soundUseCase;
            _soundView = soundView;
        }

        public void PostInitialize()
        {
            _soundUseCase.playBgm
                .Subscribe(_soundView.PlayBgm)
                .AddTo(_soundView);

            _soundUseCase.playSe
                .Subscribe(_soundView.PlaySe)
                .AddTo(_soundView);
        }
    }
}