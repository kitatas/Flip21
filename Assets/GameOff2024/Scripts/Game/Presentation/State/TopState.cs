using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2024.Game.Domain.UseCase;

namespace GameOff2024.Game.Presentation.State
{
    public sealed class TopState : BaseState
    {
        private readonly ModalUseCase _modalUseCase;

        public TopState(ModalUseCase modalUseCase)
        {
            _modalUseCase = modalUseCase;
        }

        public override GameState state => GameState.Top;

        public override async UniTask InitAsync(CancellationToken token)
        {
            await UniTask.Yield(token);
        }

        public override async UniTask<GameState> TickAsync(CancellationToken token)
        {
            var isComplete = await _modalUseCase.SetUpAsync(GameModal.Top, token);
            if (isComplete == false)
            {
                // TODO: Exception
                throw new Exception();
            }

            return GameState.Pick;
        }
    }
}