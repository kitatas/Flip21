using System;
using GameOff2024.Game.Data.DataStore;

namespace GameOff2024.Game.Domain.Repository
{
    public sealed class SkillRepository
    {
        private readonly SkillTable _skillTable;

        public SkillRepository(SkillTable skillTable)
        {
            _skillTable = skillTable;
        }

        public SkillData Find(Skill skill)
        {
            var record = _skillTable.records.Find(x => x.skill == skill);
            if (record == null || record.skillVO.icon == null)
            {
                // TODO: Exception
                throw new Exception();
            }

            return record;
        }
    }
}