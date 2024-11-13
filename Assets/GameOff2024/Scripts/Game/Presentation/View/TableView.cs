using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace GameOff2024.Game.Presentation.View
{
    public sealed class TableView : MonoBehaviour
    {
        [SerializeField] private CardView cardView = default;

        public async UniTask RenderPlayerHandsAsync(List<HandVO> playerHands, CancellationToken token)
        {
            foreach (var playerHand in playerHands)
            {
                var card = Instantiate(cardView, transform);
                card.Render(playerHand.card);
                await UniTask.Yield(token);
            }
        }

        public async UniTask RenderEnemyHandsAsync(List<HandVO> enemyHands, CancellationToken token)
        {
            foreach (var enemyHand in enemyHands)
            {
                var card = Instantiate(cardView, transform);
                card.Render(enemyHand.card);
                await UniTask.Yield(token);
            }
        }
    }
}