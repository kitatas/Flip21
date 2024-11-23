using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace GameOff2024.Game.Presentation.View
{
    public sealed class SecretCardView : MonoBehaviour
    {
        private CardView _cardView;

        public async UniTask RenderAsync(CardView cardView, float duration, CancellationToken token)
        {
            _cardView = cardView;

            await _cardView
                .TweenX(0.0f, duration)
                .WithCancellation(token);
        }

        public async UniTask OpenAsync(float duration, CancellationToken token)
        {
            await _cardView
                .Open(duration)
                .WithCancellation(token);
        }

        public async UniTask HideAsync(float duration, CancellationToken token)
        {
            if (_cardView == null) return;

            await _cardView
                .TweenX(-1300.0f, duration)
                .WithCancellation(token);

            Destroy(_cardView.gameObject);
        }
    }
}