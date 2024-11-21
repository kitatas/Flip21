using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2024.Game.Data.Entity;
using GameOff2024.Game.Domain.Repository;
using ObservableCollections;
using R3;

namespace GameOff2024.Game.Domain.UseCase
{
    public sealed class SkillUseCase
    {
        private readonly SkillEntity _skillEntity;
        private readonly SkillRepository _skillRepository;
        private readonly ObservableFixedSizeRingBuffer<SkillVO> _pickList;
        private readonly Subject<bool> _complete;
        private readonly ReactiveProperty<(int get, int lost)> _chipRate;

        public SkillUseCase(SkillEntity skillEntity, SkillRepository skillRepository)
        {
            _skillEntity = skillEntity;
            _skillRepository = skillRepository;
            _pickList = new ObservableFixedSizeRingBuffer<SkillVO>(PickConfig.MAX_NUM);
            _complete = new Subject<bool>();
            _chipRate = new ReactiveProperty<(int get, int lost)>(_skillEntity.GetChipRate());
        }

        public ObservableFixedSizeRingBuffer<SkillVO> pickList => _pickList;
        public Observable<(int get, int lost)> chipRate => _chipRate;
        public float getChipRate => _skillEntity.GetChipRate().get / SkillConfig.CHIP_RATE;
        public float lostChipRate => _skillEntity.GetChipRate().lost / SkillConfig.CHIP_RATE;

        public async UniTask<bool> LotAsync(CancellationToken token)
        {
            var random = new System.Random();
            var skills = PickConfig.SKILLS
                .OrderBy(_ => random.Next())
                .Take(PickConfig.MAX_NUM)
                .Select(x => _skillRepository.Find(x).skillVO)
                .ToList();

            for (int i = 0; i < skills.Count; i++)
            {
                _pickList[i] = skills[i];
            }

            return await _complete.AnyAsync(cancellationToken: token).AsUniTask();
        }

        public void Select(int index)
        {
            _skillEntity.Add(pickList[index]);
            _chipRate.Value = _skillEntity.GetChipRate();
            _complete?.OnNext(true);
        }
    }
}