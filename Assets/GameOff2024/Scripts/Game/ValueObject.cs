namespace GameOff2024.Game
{
    public sealed class CardVO
    {
        public readonly Suit suit;
        public readonly int rank;

        public CardVO(Suit suit, int rank)
        {
            this.suit = suit;
            this.rank = rank;
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