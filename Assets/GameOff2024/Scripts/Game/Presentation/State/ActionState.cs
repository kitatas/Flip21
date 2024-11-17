using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2024.Game.Domain.UseCase;
using GameOff2024.Game.Presentation.View;

namespace GameOff2024.Game.Presentation.State
{
    public sealed class ActionState : BaseState
    {
        private readonly ActionUseCase _actionUseCase;
        private readonly DealUseCase _dealUseCase;
        private readonly HandUseCase _handUseCase;
        private readonly ActionView _actionView;
        private readonly TableView _tableView;

        public ActionState(ActionUseCase actionUseCase, DealUseCase dealUseCase, HandUseCase handUseCase,
            ActionView actionView, TableView tableView)
        {
            _actionUseCase = actionUseCase;
            _dealUseCase = dealUseCase;
            _handUseCase = handUseCase;
            _actionView = actionView;
            _tableView = tableView;
        }

        public override GameState state => GameState.Action;

        public override async UniTask InitAsync(CancellationToken token)
        {
            _actionView.Init();
            await UniTask.Yield(token);
        }

        public override async UniTask<GameState> TickAsync(CancellationToken token)
        {
            if (_actionUseCase.IsPlayerStand() == false)
            {
                await DecisionPlayerActionAsync(token);
            }

            // check bust
            var isPlayerBust = _handUseCase.IsPlayerScoreOver(HandConfig.BUST_THRESHOLD + 1);
            var isEnemyBust = _handUseCase.IsEnemyScoreOver(HandConfig.BUST_THRESHOLD + 1);
            if (isPlayerBust && isEnemyBust) return GameState.Draw;
            if (isPlayerBust) return GameState.Lose;
            if (isEnemyBust) return GameState.Win;

            if (_actionUseCase.IsEnemyStand() == false)
            {
                await DecisionEnemyActionAsync(token);
            }

            // check bust
            isEnemyBust = _handUseCase.IsEnemyScoreOver(HandConfig.BUST_THRESHOLD + 1);
            if (isEnemyBust) return GameState.Win;

            if (_actionUseCase.IsAllStand())
            {
                var result = _handUseCase.GetResult();
                return result switch
                {
                    BattleResult.Win => GameState.Win,
                    BattleResult.Lose => GameState.Lose,
                    BattleResult.Draw => GameState.Draw,
                    _ => throw new Exception()
                };
            }

            return GameState.Action;
        }

        private async UniTask DecisionPlayerActionAsync(CancellationToken token)
        {
            var userAction = await _actionView.DecisionActionAsync(token);
            switch (userAction)
            {
                case UserAction.Hit:
                    _dealUseCase.DealToPlayer();
                    await _tableView.CreatePlayerHandAsync(_handUseCase.GetPlayerHandLast(), token);
                    break;
                case UserAction.Stand:
                    _actionUseCase.SetPlayerStand(true);
                    break;
                default:
                    // TODO: Exception
                    throw new Exception();
            }
        }

        private async UniTask DecisionEnemyActionAsync(CancellationToken token)
        {
            var userAction = _handUseCase.GetEnemyAction();
            switch (userAction)
            {
                case UserAction.Hit:
                    _dealUseCase.DealToEnemy();
                    await _tableView.CreateEnemyHandAsync(_handUseCase.GetEnemyHandLast(), token);
                    break;
                case UserAction.Stand:
                    _actionUseCase.SetEnemyStand(true);
                    break;
                default:
                    // TODO: Exception
                    throw new Exception();
            }
        }
    }
}