using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using R3;
using R3.Triggers;
using UnityEngine;

namespace GameOff2024.Common.Presentation.View.Button
{
    public abstract class BaseButtonView : MonoBehaviour
    {
        [SerializeField] protected UnityEngine.UI.Button button = default;
        private Tween _tween;

        private void Awake()
        {
            button
                .OnPointerDownAsObservable()
                .Subscribe(_ => Press())
                .AddTo(this);

            button
                .OnPointerUpAsObservable()
                .Subscribe(_ => Release())
                .AddTo(this);
        }

        private void Press()
        {
            _tween?.Kill(true);
            _tween = transform
                .DOScale(Vector3.one * 0.8f, ButtonConfig.DURATION)
                .SetEase(Ease.Linear)
                .SetLink(gameObject);
        }

        private void Release()
        {
            _tween?.Kill(true);
            _tween = transform
                .DOScale(Vector3.one, ButtonConfig.DURATION)
                .SetEase(Ease.Linear)
                .SetLink(gameObject);
        }

        public void AddAction(Action action) => button.onClick.AddListener(() => action?.Invoke());

        public void SetInteractable(bool value) => button.interactable = value;

        public Observable<Unit> OnClick() => button.OnClickAsObservable();

        public async UniTask OnClickAsync(CancellationToken token)
        {
            await button.OnClickAsync(token);
        }
    }
}