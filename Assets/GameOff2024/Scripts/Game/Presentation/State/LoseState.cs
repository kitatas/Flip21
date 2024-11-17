using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2024.Game.Domain.UseCase;

namespace GameOff2024.Game.Presentation.State
{
    public sealed class LoseState : BaseState
    {
        private readonly ChipUseCase _chipUseCase;
        private readonly ModalUseCase _modalUseCase;

        public LoseState(ChipUseCase chipUseCase, ModalUseCase modalUseCase)
        {
            _chipUseCase = chipUseCase;
            _modalUseCase = modalUseCase;
        }

        public override GameState state => GameState.Lose;

        public override async UniTask InitAsync(CancellationToken token)
        {
            await UniTask.Yield(token);
        }

        public override async UniTask<GameState> TickAsync(CancellationToken token)
        {
            var isComplete = await _modalUseCase.SetUpAsync(GameModal.Lose, token);
            if (isComplete == false)
            {
                // TODO: Exception
                throw new Exception();
            }

            return _chipUseCase.current > 0 ? GameState.Deal : GameState.None;
        }
    }
}