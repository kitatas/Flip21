using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UniEx;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace GameOff2024.Common.Presentation.View.Modal
{
    public abstract class BaseModalView : MonoBehaviour
    {
        [SerializeField] protected CanvasGroup canvasGroup = default;
        [SerializeField] private Volume volume = default;
        private Tween _tween;

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
            _tween?.Kill();
            _tween = DOTween.Sequence()
                .AppendCallback(() => canvasGroup.blocksRaycasts = true)
                .Append(canvasGroup
                    .DOFade(1.0f, duration)
                    .SetEase(Ease.OutBack))
                .Join(canvasGroup.transform.ToRectTransform()
                    .DOScale(Vector3.one, duration)
                    .SetEase(Ease.OutBack))
                .SetLink(gameObject);

            return _tween;
        }

        public virtual async UniTask HideAsync(float duration, CancellationToken token)
        {
            await Hide(duration)
                .WithCancellation(token);
        }

        public Tween Hide(float duration)
        {
            _tween?.Kill();
            _tween = DOTween.Sequence()
                .Append(canvasGroup
                    .DOFade(0.0f, duration)
                    .SetEase(Ease.OutQuart))
                .Join(canvasGroup.transform.ToRectTransform()
                    .DOScale(Vector3.one * 0.8f, duration)
                    .SetEase(Ease.OutQuart))
                .AppendCallback(() => canvasGroup.blocksRaycasts = false)
                .SetLink(gameObject);

            return _tween;
        }

        protected async UniTask TweenBlurAsync(float value, float duration, CancellationToken token)
        {
            volume.profile.TryGet(out DepthOfField depthOfField);
            if (depthOfField)
            {
                await DOTween
                    .To(
                        () => depthOfField.focusDistance.value,
                        x => depthOfField.focusDistance.value = x,
                        value,
                        duration)
                    .WithCancellation(token);
            }
        }
    }
}