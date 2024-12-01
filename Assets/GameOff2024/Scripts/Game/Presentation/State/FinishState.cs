using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2024.Common;
using GameOff2024.Common.Domain.UseCase;
using GameOff2024.Game.Presentation.View.Button;
using GameOff2024.Game.Presentation.View.Modal;

namespace GameOff2024.Game.Presentation.State
{
    public sealed class FinishState : BaseState
    {
        private readonly SceneUseCase _sceneUseCase;
        private readonly HomeButtonView _homeButtonView;
        private readonly MainModalView _mainModalView;

        public FinishState(SceneUseCase sceneUseCase, HomeButtonView homeButtonView, MainModalView mainModalView)
        {
            _sceneUseCase = sceneUseCase;
            _homeButtonView = homeButtonView;
            _mainModalView = mainModalView;
        }

        public override GameState state => GameState.Finish;

        public override async UniTask InitAsync(CancellationToken token)
        {
            _homeButtonView.AddAction(() => _sceneUseCase.Load(SceneName.Game));
            await UniTask.Yield(token);
        }

        public override async UniTask<GameState> TickAsync(CancellationToken token)
        {
            await _mainModalView.HideAsync(ModalConfig.DURATION, token);

            _sceneUseCase.Load(SceneName.Game);

            return GameState.None;
        }
    }
}