using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2024.Game.Domain.Repository;
using ObservableCollections;
using R3;

namespace GameOff2024.Game.Domain.UseCase
{
    public sealed class SkillUseCase
    {
        private readonly SkillRepository _skillRepository;
        private readonly ObservableFixedSizeRingBuffer<SkillVO> _pickList;
        private readonly Subject<bool> _complete;

        public SkillUseCase(SkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
            _pickList = new ObservableFixedSizeRingBuffer<SkillVO>(PickConfig.MAX_NUM);
            _complete = new Subject<bool>();
        }

        public ObservableFixedSizeRingBuffer<SkillVO> pickList => _pickList;

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
            // TODO: スキル保持 pickList[index]
            _complete?.OnNext(true);
        }
    }
}