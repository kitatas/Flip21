using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2024.Game.Domain.UseCase;
using GameOff2024.Game.Presentation.View;

namespace GameOff2024.Game.Presentation.State
{
    public sealed class WinState : BaseState
    {
        private readonly ChipUseCase _chipUseCase;
        private readonly ModalUseCase _modalUseCase;
        private readonly TableView _tableView;

        public WinState(ChipUseCase chipUseCase, ModalUseCase modalUseCase, TableView tableView)
        {
            _chipUseCase = chipUseCase;
            _modalUseCase = modalUseCase;
            _tableView = tableView;
        }

        public override GameState state => GameState.Win;

        public override async UniTask InitAsync(CancellationToken token)
        {
            await UniTask.Yield(token);
        }

        public override async UniTask<GameState> TickAsync(CancellationToken token)
        {
            await _tableView.OpenEnemyHandsAsync(token);

            var isComplete = await _modalUseCase.SetUpAsync(GameModal.Win, token);
            if (isComplete == false)
            {
                // TODO: Exception
                throw new Exception();
            }

            return _chipUseCase.current < GameConfig.CLEAR_THRESHOLD ? GameState.Bet : GameState.None;
        }
    }
}