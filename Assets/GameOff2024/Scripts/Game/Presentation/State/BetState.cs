using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2024.Game.Domain.UseCase;

namespace GameOff2024.Game.Presentation.State
{
    public sealed class BetState : BaseState
    {
        private readonly ModalUseCase _modalUseCase;

        public BetState(ModalUseCase modalUseCase)
        {
            _modalUseCase = modalUseCase;
        }

        public override GameState state => GameState.Bet;

        public override async UniTask InitAsync(CancellationToken token)
        {
            await UniTask.Yield(token);
        }

        public override async UniTask<GameState> TickAsync(CancellationToken token)
        {
            _modalUseCase.SetUp(GameModal.Bet);
            var isComplete = await _modalUseCase.IsCompleteAsync(token);
            if (isComplete == false)
            {
                // TODO: Exception
                throw new Exception();
            }

            return GameState.None;
        }
    }
}