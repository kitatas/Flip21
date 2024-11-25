using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2024.Common;
using GameOff2024.Common.Domain.UseCase;

namespace GameOff2024.Boot.Presentation.State
{
    public sealed class CheckState : BaseState
    {
        private readonly SceneUseCase _sceneUseCase;

        public CheckState(SceneUseCase sceneUseCase)
        {
            _sceneUseCase = sceneUseCase;
        }

        public override BootState state => BootState.Check;

        public override async UniTask InitAsync(CancellationToken token)
        {
            await UniTask.Yield(token);
        }

        public override async UniTask<BootState> TickAsync(CancellationToken token)
        {
            await UniTask.Yield(token);

            _sceneUseCase.Load(SceneName.Game);

            return BootState.None;
        }
    }
}