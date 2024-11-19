using System;
using UnityEngine;

namespace GameOff2024.Game
{
    public sealed class CardVO
    {
        public readonly SuitVO suit;
        public readonly int rank;

        public CardVO(SuitVO suit, int rank)
        {
            this.suit = suit;
            this.rank = rank;
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

    [Serializable]
    public sealed class SuitVO
    {
        public readonly Sprite icon;
        public readonly Color color;

        public SuitVO(Sprite icon, Color color)
        {
            this.icon = icon;
            this.color = color;
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