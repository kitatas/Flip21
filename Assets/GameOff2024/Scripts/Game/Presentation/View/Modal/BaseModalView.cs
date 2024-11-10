using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace GameOff2024.Game.Presentation.View.Modal
{
    public abstract class BaseModalView : MonoBehaviour
    {
        [SerializeField] protected CanvasGroup canvasGroup = default;

        public abstract GameModal modal { get; }

        public virtual async UniTask InitAsync(CancellationToken token)
        {
            Hide();
            await UniTask.Yield(token);
        }

        public async UniTask ShowAsync(CancellationToken token)
        {
            Show();
            await UniTask.Yield(token);
        }

        public async UniTask HideAsync(CancellationToken token)
        {
            Hide();
            await UniTask.Yield(token);
        }

        public virtual void Show()
        {
            canvasGroup.alpha = 1.0f;
            canvasGroup.interactable = true;
        }

        public virtual void Hide()
        {
            canvasGroup.alpha = 0.0f;
            canvasGroup.interactable = false;
        }
    }
}