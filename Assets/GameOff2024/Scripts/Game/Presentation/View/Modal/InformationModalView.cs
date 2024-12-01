using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2024.Common;

namespace GameOff2024.Game.Presentation.View.Modal
{
    public sealed class InformationModalView : GameModalView
    {
        public override GameModal modal => GameModal.None;

        public override async UniTask ShowAsync(float duration, CancellationToken token)
        {
            await (
                base.ShowAsync(duration, token),
                TweenBlurAsync(ModalConfig.ACTIVATE_BLUR_VALUE, duration, token)
            );
        }

        public override async UniTask HideAsync(float duration, CancellationToken token)
        {
            await (
                base.HideAsync(duration, token),
                TweenBlurAsync(ModalConfig.DEACTIVATE_BLUR_VALUE, duration, token)
            );
        }
    }
}