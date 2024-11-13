using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2024.Game.Domain.UseCase;
using GameOff2024.Game.Presentation.View;

namespace GameOff2024.Game.Presentation.State
{
    public sealed class DealState : BaseState
    {
        private readonly DealUseCase _dealUseCase;
        private readonly HandUseCase _handUseCase;
        private readonly TableView _tableView;

        public DealState(DealUseCase dealUseCase, HandUseCase handUseCase, TableView tableView)
        {
            _dealUseCase = dealUseCase;
            _handUseCase = handUseCase;
            _tableView = tableView;
        }

        public override GameState state => GameState.Deal;

        public override async UniTask InitAsync(CancellationToken token)
        {
            _dealUseCase.Init();
            await UniTask.Yield(token);
        }

        public override async UniTask<GameState> TickAsync(CancellationToken token)
        {
            _dealUseCase.SetUp();

            await (
                _tableView.RenderPlayerHandsAsync(_handUseCase.GetPlayerHands(), token),
                _tableView.RenderEnemyHandsAsync(_handUseCase.GetEnemyHands(), token)
            );

            return GameState.None;
        }
    }
}