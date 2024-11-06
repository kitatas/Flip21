using GameOff2024.Game.Data.Entity;

namespace GameOff2024.Game.Domain.UseCase
{
    public sealed class DealUseCase
    {
        private readonly DeckEntity _deckEntity;
        private HandEntity _playerHandEntity;
        private HandEntity _enemyHandEntity;

        public DealUseCase(DeckEntity deckEntity)
        {
            _deckEntity = deckEntity;
        }

        public void SetUp()
        {
            _deckEntity.Refresh();
            InitHand();
        }

        private void InitHand()
        {
            _playerHandEntity = new HandEntity();
            _enemyHandEntity = new HandEntity();

            // 初期カード配布
            DealToPlayer();
            DealToEnemy();
        }

        public void DealToPlayer()
        {
            _playerHandEntity.Add(_deckEntity.Draw());
        }

        public void DealToEnemy()
        {
            _enemyHandEntity.Add(_deckEntity.Draw());
        }
    }
}