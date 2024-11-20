using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2024.Common.Presentation.View.Button;
using GameOff2024.Common.Presentation.View.Modal;
using UnityEngine;

namespace GameOff2024.Game.Presentation.View.Modal
{
    public abstract class GameModalView : BaseModalView
    {
        [SerializeField] protected CommonButtonView decision = default;

        public abstract GameModal modal { get; }

        public async UniTask PopAsync(float duration, CancellationToken token)
        {
            await ShowAsync(duration, token);
            await decision.OnClickAsync(token);
            await HideAsync(duration, token);
        }
    }
}