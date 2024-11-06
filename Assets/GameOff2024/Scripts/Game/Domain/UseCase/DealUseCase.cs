using GameOff2024.Game.Data.Entity;

namespace GameOff2024.Game.Domain.UseCase
{
    public sealed class DealUseCase
    {
        private readonly DeckEntity _deckEntity;

        public DealUseCase(DeckEntity deckEntity)
        {
            _deckEntity = deckEntity;
        }

        public void SetUp()
        {
            _deckEntity.Shuffle();
        }
    }
}