using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2024.Game.Domain.UseCase;
using GameOff2024.Game.Presentation.View;

namespace GameOff2024.Game.Presentation.State
{
    public sealed class DrawState : BaseState
    {
        private readonly ModalUseCase _modalUseCase;
        private readonly TableView _tableView;

        public DrawState(ModalUseCase modalUseCase, TableView tableView)
        {
            _modalUseCase = modalUseCase;
            _tableView = tableView;
        }

        public override GameState state => GameState.Draw;

        public override async UniTask InitAsync(CancellationToken token)
        {
            await UniTask.Yield(token);
        }

        public override async UniTask<GameState> TickAsync(CancellationToken token)
        {
            await _tableView.OpenEnemyHandsAsync(token);

            var isComplete = await _modalUseCase.SetUpAsync(GameModal.Draw, token);
            if (isComplete == false)
            {
                // TODO: Exception
                throw new Exception();
            }

            return GameState.Bet;
        }
    }
}