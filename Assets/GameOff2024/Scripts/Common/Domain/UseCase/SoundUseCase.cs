using GameOff2024.Common.Domain.Repository;
using R3;

namespace GameOff2024.Common.Domain.UseCase
{
    public sealed class SoundUseCase
    {
        private readonly SoundRepository _soundRepository;
        private readonly Subject<BgmVO> _playBgm;
        private readonly Subject<SeVO> _playSe;
        private readonly ReactiveProperty<float> _bgmVolume;
        private readonly ReactiveProperty<float> _seVolume;

        public SoundUseCase(SoundRepository soundRepository)
        {
            _soundRepository = soundRepository;
            _playBgm = new Subject<BgmVO>();
            _playSe = new Subject<SeVO>();
            _bgmVolume = new ReactiveProperty<float>(0.5f);
            _seVolume = new ReactiveProperty<float>(0.5f);
        }

        public Observable<BgmVO> playBgm => _playBgm;
        public Observable<SeVO> playSe => _playSe;
        public Observable<float> bgmVolume => _bgmVolume;
        public Observable<float> seVolume => _seVolume;
        public (float bgm, float se) volume => (_bgmVolume.Value, _seVolume.Value);

        public void PlayBgm(Bgm bgm)
        {
            var record = _soundRepository.Find(bgm);
            _playBgm?.OnNext(record);
        }

        public void PlaySe(Se se)
        {
            var record = _soundRepository.Find(se);
            _playSe?.OnNext(record);
        }

        public void SetBgmVolume(float value)
        {
            _bgmVolume.Value = value;
        }

        public void SetSeVolume(float value)
        {
            _seVolume.Value = value;
        }
    }
}