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

        public virtual async UniTask ShowAsync(float duration, CancellationToken token)
        {
            Show(duration);
            await UniTask.Yield(token);
        }

        public void Show(float duration)
        {
            canvasGroup.alpha = 1.0f;
            canvasGroup.blocksRaycasts = true;
        }

        public virtual async UniTask HideAsync(float duration, CancellationToken token)
        {
            Hide(duration);
            await UniTask.Yield(token);
        }

        public void Hide(float duration)
        {
            canvasGroup.alpha = 0.0f;
            canvasGroup.blocksRaycasts = false;
        }
    }
}