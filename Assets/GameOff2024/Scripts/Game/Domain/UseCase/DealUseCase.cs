using GameOff2024.Game.Data.Entity;

namespace GameOff2024.Game.Domain.UseCase
{
    public sealed class DealUseCase
    {
        private readonly DeckEntity _deckEntity;
        private readonly PlayerHandEntity _playerHandEntity;
        private readonly EnemyHandEntity _enemyHandEntity;

        public DealUseCase(DeckEntity deckEntity, PlayerHandEntity playerHandEntity, EnemyHandEntity enemyHandEntity)
        {
            _deckEntity = deckEntity;
            _playerHandEntity = playerHandEntity;
            _enemyHandEntity = enemyHandEntity;
        }

        public void SetUp()
        {
            _deckEntity.Refresh();

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