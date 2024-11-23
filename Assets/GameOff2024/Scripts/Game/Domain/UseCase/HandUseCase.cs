using System.Collections.Generic;
using System.Linq;
using GameOff2024.Game.Data.Entity;
using GameOff2024.Game.Utility;

namespace GameOff2024.Game.Domain.UseCase
{
    public sealed class HandUseCase
    {
        private readonly DeckEntity _deckEntity;
        private readonly PlayerHandEntity _playerHandEntity;
        private readonly EnemyHandEntity _enemyHandEntity;
        private readonly UpsetEntity _upsetEntity;

        public HandUseCase(DeckEntity deckEntity, PlayerHandEntity playerHandEntity, EnemyHandEntity enemyHandEntity,
            UpsetEntity upsetEntity)
        {
            _deckEntity = deckEntity;
            _playerHandEntity = playerHandEntity;
            _enemyHandEntity = enemyHandEntity;
            _upsetEntity = upsetEntity;
        }

        public List<HandVO> GetPlayerHands()
        {
            return _playerHandEntity.hands
                .Select((v, i) => new HandVO(i, _deckEntity.GetCard(v)))
                .ToList();
        }

        public List<HandVO> GetEnemyHands()
        {
            return _enemyHandEntity.hands
                .Select((v, i) => new HandVO(i, _deckEntity.GetCard(v)))
                .ToList();
        }

        public HandVO GetPlayerHandLast() => GetPlayerHands().Last();
        public HandVO GetEnemyHandLast() => GetEnemyHands().Last();

        public int GetPlayerHandsScore() => _upsetEntity.isUpset
            ? GetPlayerHands().GetHandScore() + _deckEntity.GetCard(_upsetEntity.index).rank
            : GetPlayerHands().GetHandScore();

        public int GetEnemyHandsScore() => _upsetEntity.isUpset
            ? GetEnemyHands().GetHandScore() + _deckEntity.GetCard(_upsetEntity.index).rank
            : GetEnemyHands().GetHandScore();

        public bool IsPlayerScoreOver(int value) => GetPlayerHandsScore() >= value;
        public bool IsEnemyScoreOver(int value) => GetEnemyHandsScore() >= value;

        public UserAction GetEnemyAction() => IsEnemyScoreOver(17) ? UserAction.Stand : UserAction.Hit;

        public BattleResult GetResult()
        {
            var type = GetPlayerHandsScore() - GetEnemyHandsScore();
            return type switch
            {
                > 0 => BattleResult.Win,
                < 0 => BattleResult.Lose,
                0 => BattleResult.Draw,
            };
        }
    }
}