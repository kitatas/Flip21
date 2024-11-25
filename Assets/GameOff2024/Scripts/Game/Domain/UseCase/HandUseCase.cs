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

        public IEnumerable<HandVO> GetPlayerHands()
        {
            return _playerHandEntity.hands
                .Select((v, i) => new HandVO(i, _deckEntity.GetCard(v)));
        }

        public IEnumerable<HandVO> GetEnemyHands()
        {
            return _enemyHandEntity.hands
                .Select((v, i) => new HandVO(i, _deckEntity.GetCard(v)));
        }

        public HandVO GetPlayerHandLast() => GetPlayerHands().Last();
        public HandVO GetEnemyHandLast() => GetEnemyHands().Last();

        public int GetPlayerHandsScore()
        {
            var hands = _playerHandEntity.hands;
            if (_upsetEntity.isUpset) hands.Add(_upsetEntity.index);

            return hands
                .Select((v, i) => new HandVO(i, _deckEntity.GetCard(v)))
                .GetHandScore();
        }

        public int GetEnemyHandsScore()
        {
            var hands = _enemyHandEntity.hands;
            if (_upsetEntity.isUpset) hands.Add(_upsetEntity.index);

            return hands
                .Select((v, i) => new HandVO(i, _deckEntity.GetCard(v)))
                .GetHandScore();
        }

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