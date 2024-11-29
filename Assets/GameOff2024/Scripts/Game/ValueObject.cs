using System;
using UnityEngine;

namespace GameOff2024.Game
{
    public sealed class CardVO
    {
        public readonly int rank;
        public readonly Sprite sprite;

        public CardVO(int rank, Sprite sprite)
        {
            this.rank = rank;
            this.sprite = sprite;
        }

        public string GetRankString()
        {
            return rank switch
            {
                1 => "A",
                11 => "J",
                12 => "Q",
                13 => "K",
                _ => rank.ToString()
            };
        }
    }

    public sealed class HandVO
    {
        public readonly int index;
        public readonly CardVO card;

        public HandVO(int index, CardVO card)
        {
            this.index = index;
            this.card = card;
        }
    }

    [Serializable]
    public sealed class SkillVO
    {
        public readonly Skill skill;
        public readonly Sprite icon;
        public readonly int value;

        public SkillVO(Skill skill, Sprite icon, int value)
        {
            this.skill = skill;
            this.icon = icon;
            this.value = value;
        }
    }
}