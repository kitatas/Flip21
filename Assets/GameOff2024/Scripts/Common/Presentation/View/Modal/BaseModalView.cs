using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UniEx;
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
            await Show(duration)
                .WithCancellation(token);
        }

        public Tween Show(float duration)
        {
            return DOTween.Sequence()
                .AppendCallback(() => canvasGroup.blocksRaycasts = true)
                .Append(canvasGroup
                    .DOFade(1.0f, duration)
                    .SetEase(Ease.OutBack))
                .Join(canvasGroup.transform.ToRectTransform()
                    .DOScale(Vector3.one, duration)
                    .SetEase(Ease.OutBack))
                .SetLink(gameObject);
        }

        public virtual async UniTask HideAsync(float duration, CancellationToken token)
        {
            await Hide(duration)
                .WithCancellation(token);
        }

        public Tween Hide(float duration)
        {
            return DOTween.Sequence()
                .Append(canvasGroup
                    .DOFade(0.0f, duration)
                    .SetEase(Ease.OutQuart))
                .Join(canvasGroup.transform.ToRectTransform()
                    .DOScale(Vector3.one * 0.8f, duration)
                    .SetEase(Ease.OutQuart))
                .AppendCallback(() => canvasGroup.blocksRaycasts = false)
                .SetLink(gameObject);
        }
    }
}