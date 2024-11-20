using System.Linq;
using GameOff2024.Game.Domain.Repository;
using ObservableCollections;

namespace GameOff2024.Game.Domain.UseCase
{
    public sealed class SkillUseCase
    {
        private readonly SkillRepository _skillRepository;
        private readonly ObservableFixedSizeRingBuffer<SkillVO> _pickList;

        public SkillUseCase(SkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
            _pickList = new ObservableFixedSizeRingBuffer<SkillVO>(PickConfig.MAX_NUM);
        }

        public ObservableFixedSizeRingBuffer<SkillVO> pickList => _pickList;

        public void Lot()
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
        }
    }
}