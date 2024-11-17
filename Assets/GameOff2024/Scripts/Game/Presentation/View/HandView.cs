using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using GameOff2024.Common.Utility;
using UniEx;
using UnityEngine;

namespace GameOff2024.Game.Presentation.View
{
    public sealed class HandView : MonoBehaviour
    {
        private List<CardView> _handCards;

        public void Init()
        {
            _handCards = new List<CardView>();
        }

        public async UniTask RenderHandAsync(CardView cardView, float duration, CancellationToken token)
        {
            cardView.transform.SetParent(transform);
            _handCards.Add(cardView);

            await (
                cardView.TweenY(0.0f, duration).WithCancellation(token),
                TweenHandCardsAsync(duration, token)
            );
        }

        private async UniTask TweenHandCardsAsync(float duration, CancellationToken token)
        {
            var cardCount = _handCards.Count;
            var pointX = cardCount.IsEven()
                ? -1.0f * CardConfig.HAND_INTERVAL * (cardCount * 0.5f - 0.5f)
                : -1.0f * CardConfig.HAND_INTERVAL * Mathf.Floor(cardCount * 0.5f);

            for (int i = 0; i < cardCount; i++)
            {
                _handCards[i].TweenX(pointX, duration);
                pointX += CardConfig.HAND_INTERVAL;
            }

            await UniTaskHelper.DelayAsync(duration, token);
        }

        public async UniTask RotateAsync(float duration, CancellationToken token)
        {
            for (int i = 0; i < _handCards.Count; i++)
            {
                _handCards[i].Open(duration)
                    .SetDelay(0.25f * i);
            }

            await UniTaskHelper.DelayAsync(duration * 2.0f, token);
        }
    }
}