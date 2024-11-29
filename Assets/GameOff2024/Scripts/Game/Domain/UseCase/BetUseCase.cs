using GameOff2024.Game.Data.Entity;
using R3;
using UnityEngine;

namespace GameOff2024.Game.Domain.UseCase
{
    public sealed class BetUseCase
    {
        private readonly ChipEntity _chipEntity;
        private readonly ReactiveProperty<int> _bet;

        public BetUseCase(ChipEntity chipEntity)
        {
            _chipEntity = chipEntity;
            _bet = new ReactiveProperty<int>(0);
        }

        public Observable<int> bet => _bet;
        public Observable<bool> isPlus => _bet.Select(x => x < _chipEntity.current);
        public Observable<bool> isMinus => _bet.Select(x => x > 0);
        public int betValue => _bet.Value;

        public void Add(int value)
        {
            var over = betValue % ChipConfig.BET_RATE;
            if (over == 0)
            {
                _bet.Value = Mathf.Clamp(betValue + value, 0, _chipEntity.current);
            }
            else
            {
                // 端数が出ている = AllBet なので減算のみ
                _bet.Value -= over;
            }
        }

        public void Reset() => _bet.Value = 0;
    }
}