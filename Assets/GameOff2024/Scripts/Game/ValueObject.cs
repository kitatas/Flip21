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
}