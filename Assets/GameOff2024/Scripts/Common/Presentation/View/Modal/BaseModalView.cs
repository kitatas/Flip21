using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace GameOff2024.Common.Presentation.View.Modal
{
    public abstract class BaseModalView : MonoBehaviour
    {
        [SerializeField] protected CanvasGroup canvasGroup = default;

        public virtual async UniTask InitAsync(CancellationToken token)
        {
            await HideAsync(0.0f, token);
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