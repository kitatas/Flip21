using System;
using UnityEngine;

namespace GameOff2024.Game.Data.Entity
{
    public sealed class SkillEntity
    {
        public int chipGetRate { get; private set; }
        public int chipLostRate { get; private set; }

        public SkillEntity()
        {
            chipGetRate = SkillConfig.INIT_CHIP_RATE;
            chipLostRate = SkillConfig.INIT_CHIP_RATE;
        }

        public void Add(SkillVO skill)
        {
            switch (skill.skill)
            {
                case Skill.ChipGetUp:
                    chipGetRate += skill.value;
                    break;
                case Skill.ChipLostDown:
                    chipLostRate = Mathf.Min(chipLostRate - skill.value, 0);
                    break;
                case Skill.ChipGetLostUp:
                    chipGetRate += skill.value;
                    chipLostRate += skill.value;
                    break;
                case Skill.ChipGetLostDown:
                    chipGetRate = Mathf.Max(chipGetRate - skill.value, 0);
                    chipLostRate = Mathf.Min(chipLostRate - skill.value, 0);
                    break;
                default:
                    throw new Exception();
            }
        }

        public (int get, int lost) GetChipRate() => (chipGetRate, chipLostRate);
    }
}