using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2024.Game.Domain.UseCase;

namespace GameOff2024.Game.Presentation.State
{
    public sealed class BetState : BaseState
    {
        private readonly BetUseCase _betUseCase;
        private readonly ChipUseCase _chipUseCase;
        private readonly ModalUseCase _modalUseCase;

        public BetState(BetUseCase betUseCase, ChipUseCase chipUseCase, ModalUseCase modalUseCase)
        {
            _betUseCase = betUseCase;
            _chipUseCase = chipUseCase;
            _modalUseCase = modalUseCase;
        }

        public override GameState state => GameState.Bet;

        public override async UniTask InitAsync(CancellationToken token)
        {
            await UniTask.Yield(token);
        }

        public override async UniTask<GameState> TickAsync(CancellationToken token)
        {
            var isComplete = await _modalUseCase.SetUpAsync(GameModal.Bet, token);
            if (isComplete == false)
            {
                // TODO: Exception
                throw new Exception();
            }

            _chipUseCase.Bet(_betUseCase.betValue);

            return GameState.Deal;
        }
    }
}