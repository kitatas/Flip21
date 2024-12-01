using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2024.Common;
using GameOff2024.Common.Domain.UseCase;
using GameOff2024.Common.Presentation.View.Button;
using UnityEngine;

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

            var buttons = Object.FindObjectsByType<BaseButtonView>(default);
            foreach (var button in buttons)
            {
                button.AddAction(() => _soundUseCase.PlaySe(Se.Button));
            }

            await UniTask.Yield(token);
        }

        public override async UniTask<BootState> TickAsync(CancellationToken token)
        {
            await UniTask.Yield(token);
            return BootState.Login;
        }
    }
}