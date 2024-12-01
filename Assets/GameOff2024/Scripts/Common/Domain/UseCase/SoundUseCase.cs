using GameOff2024.Common.Domain.Repository;
using R3;

namespace GameOff2024.Common.Domain.UseCase
{
    public sealed class SoundUseCase
    {
        private readonly SoundRepository _soundRepository;
        private readonly Subject<SeVO> _playSe;

        public SoundUseCase(SoundRepository soundRepository)
        {
            _soundRepository = soundRepository;
            _playSe = new Subject<SeVO>();
        }

        public Observable<SeVO> playSe => _playSe;

        public void PlaySe(Se se)
        {
            var record = _soundRepository.Find(se);
            _playSe?.OnNext(record);
        }
    }
}