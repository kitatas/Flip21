using GameOff2024.Game.Data.Entity;
using GameOff2024.Game.Domain.Repository;

namespace GameOff2024.Game.Domain.UseCase
{
    public sealed class DealUseCase
    {
        private readonly DeckEntity _deckEntity;
        private readonly PlayerHandEntity _playerHandEntity;
        private readonly EnemyHandEntity _enemyHandEntity;
        private readonly SuitRepository _suitRepository;

        public DealUseCase(DeckEntity deckEntity, PlayerHandEntity playerHandEntity, EnemyHandEntity enemyHandEntity,
            SuitRepository suitRepository)
        {
            _deckEntity = deckEntity;
            _playerHandEntity = playerHandEntity;
            _enemyHandEntity = enemyHandEntity;
            _suitRepository = suitRepository;
        }

        public void Init()
        {
            _deckEntity.Build(x => _suitRepository.Find(x).suitVO);
        }

        public void SetUp()
        {
            _deckEntity.Refresh();
            _playerHandEntity.Clear();
            _enemyHandEntity.Clear();

            // 初期カード配布
            for (int i = 0; i < GameConfig.INIT_CARD_NUM; i++)
            {
                DealToPlayer();
                DealToEnemy();
            }
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