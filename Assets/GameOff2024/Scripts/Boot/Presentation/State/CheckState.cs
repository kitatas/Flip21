using System.Threading;
using Cysharp.Threading.Tasks;

namespace GameOff2024.Boot.Presentation.State
{
    public sealed class CheckState : BaseState
    {
        public override BootState state => BootState.Check;

        public override async UniTask InitAsync(CancellationToken token)
        {
            await UniTask.Yield(token);
        }

        public override async UniTask<BootState> TickAsync(CancellationToken token)
        {
            await UniTask.Yield(token);
            return BootState.None;
        }
    }
}