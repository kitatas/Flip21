using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2024.Game.Domain.UseCase;
using GameOff2024.Game.Presentation.View;

namespace GameOff2024.Game.Presentation.State
{
    public sealed class DealState : BaseState
    {
        private readonly ActionUseCase _actionUseCase;
        private readonly DealUseCase _dealUseCase;
        private readonly HandUseCase _handUseCase;
        private readonly TableView _tableView;

        public DealState(ActionUseCase actionUseCase, DealUseCase dealUseCase, HandUseCase handUseCase,
            TableView tableView)
        {
            _actionUseCase = actionUseCase;
            _dealUseCase = dealUseCase;
            _handUseCase = handUseCase;
            _tableView = tableView;
        }

        public override GameState state => GameState.Deal;

        public override async UniTask InitAsync(CancellationToken token)
        {
            _dealUseCase.Init();
            _tableView.Init();
            await UniTask.Yield(token);
        }

        public override async UniTask<GameState> TickAsync(CancellationToken token)
        {
            _actionUseCase.SetUp();
            _dealUseCase.SetUp();

            await (
                _tableView.RenderPlayerHandsAsync(_handUseCase.GetPlayerHands(), token),
                _tableView.RenderEnemyHandsAsync(_handUseCase.GetEnemyHands(), token)
            );

            return GameState.Action;
        }
    }
}