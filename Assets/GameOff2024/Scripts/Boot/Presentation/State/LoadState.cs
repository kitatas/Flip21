using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2024.Common;
using GameOff2024.Common.Domain.UseCase;

namespace GameOff2024.Boot.Presentation.State
{
    public sealed class LoadState : BaseState
    {
        private readonly SoundUseCase _soundUseCase;

        public LoadState(SoundUseCase soundUseCase)
        {
            _soundUseCase = soundUseCase;
        }

        public override BootState state => BootState.Load;

        public override async UniTask InitAsync(CancellationToken token)
        {
            _soundUseCase.PlayBgm(Bgm.Main);

            await UniTask.Yield(token);
        }

        public override async UniTask<BootState> TickAsync(CancellationToken token)
        {
            await UniTask.Yield(token);
            return BootState.Login;
        }
    }
}