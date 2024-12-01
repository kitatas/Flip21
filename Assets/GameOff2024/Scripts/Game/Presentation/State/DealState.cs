using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2024.Common;
using GameOff2024.Common.Domain.UseCase;
using GameOff2024.Game.Domain.UseCase;
using GameOff2024.Game.Presentation.View;

namespace GameOff2024.Game.Presentation.State
{
    public sealed class DealState : BaseState
    {
        private readonly SoundUseCase _soundUseCase;
        private readonly ActionUseCase _actionUseCase;
        private readonly DealUseCase _dealUseCase;
        private readonly HandUseCase _handUseCase;
        private readonly TurnUseCase _turnUseCase;
        private readonly TableView _tableView;

        public DealState(SoundUseCase soundUseCase, ActionUseCase actionUseCase, DealUseCase dealUseCase,
            HandUseCase handUseCase, TurnUseCase turnUseCase, TableView tableView)
        {
            _soundUseCase = soundUseCase;
            _actionUseCase = actionUseCase;
            _dealUseCase = dealUseCase;
            _handUseCase = handUseCase;
            _turnUseCase = turnUseCase;
            _tableView = tableView;
        }

        public override GameState state => GameState.Deal;

        public override async UniTask InitAsync(CancellationToken token)
        {
            _dealUseCase.Init();
            _tableView.Init(() => _soundUseCase.PlaySe(Se.Deal));
            await UniTask.Yield(token);
        }

        public override async UniTask<GameState> TickAsync(CancellationToken token)
        {
            _actionUseCase.SetUp();
            _dealUseCase.SetUp();
            _turnUseCase.Increment();
            await _tableView.SetUpAsync(token);

            await _tableView.RenderSecretCardAsync(_dealUseCase.GetSecretCard(), token);

            await (
                _tableView.RenderPlayerHandsAsync(_handUseCase.GetPlayerHands(), token),
                _tableView.RenderEnemyHandsAsync(_handUseCase.GetEnemyHands(), token)
            );

            return GameState.Action;
        }
    }
}