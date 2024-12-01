using GameOff2024.Common.Domain.UseCase;
using GameOff2024.Game.Presentation.View;
using R3;
using VContainer.Unity;

namespace GameOff2024.Game.Presentation.Presenter
{
    public sealed class VolumePresenter : IStartable
    {
        private readonly SoundUseCase _soundUseCase;
        private readonly VolumeView _volumeView;

        public VolumePresenter(SoundUseCase soundUseCase, VolumeView volumeView)
        {
            _soundUseCase = soundUseCase;
            _volumeView = volumeView;
        }

        public void Start()
        {
            _volumeView.Init(_soundUseCase.volume);

            _volumeView.bgmVolume
                .Subscribe(_soundUseCase.SetBgmVolume)
                .AddTo(_volumeView);

            _volumeView.seVolume
                .Subscribe(_soundUseCase.SetSeVolume)
                .AddTo(_volumeView);

            _volumeView.releaseVolume
                .Subscribe(_soundUseCase.PlaySe)
                .AddTo(_volumeView);
        }
    }
}