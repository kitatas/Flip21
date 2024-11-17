using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2024.Common.Presentation.View.Button;
using UnityEngine;

namespace GameOff2024.Game.Presentation.View.Modal
{
    public abstract class BaseModalView : MonoBehaviour
    {
        [SerializeField] protected CanvasGroup canvasGroup = default;
        [SerializeField] protected CommonButtonView decision = default;

        public abstract GameModal modal { get; }

        public virtual async UniTask InitAsync(CancellationToken token)
        {
            await HideAsync(0.0f, token);
        }

        public async UniTask PopAsync(float duration, CancellationToken token)
        {
            await ShowAsync(duration, token);
            await decision.OnClickAsync(token);
            await HideAsync(duration, token);
        }

        protected virtual async UniTask ShowAsync(float duration, CancellationToken token)
        {
            canvasGroup.alpha = 1.0f;
            canvasGroup.blocksRaycasts = true;
            await UniTask.Yield(token);
        }

        protected virtual async UniTask HideAsync(float duration, CancellationToken token)
        {
            canvasGroup.alpha = 0.0f;
            canvasGroup.blocksRaycasts = false;
            await UniTask.Yield(token);
        }
    }
}