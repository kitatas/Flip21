using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2024.Game.Domain.UseCase;
using GameOff2024.Game.Presentation.View.Modal;

namespace GameOff2024.Game.Presentation.State
{
    public sealed class TopState : BaseState
    {
        private readonly ModalUseCase _modalUseCase;
        private readonly MainModalView _mainModalView;

        public TopState(ModalUseCase modalUseCase, MainModalView mainModalView)
        {
            _modalUseCase = modalUseCase;
            _mainModalView = mainModalView;
        }

        public override GameState state => GameState.Top;

        public override async UniTask InitAsync(CancellationToken token)
        {
            _mainModalView.InitAsync(token).Forget();
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

            await _mainModalView.ShowAsync(ModalConfig.DURATION, token);

            return GameState.Pick;
        }
    }
}