using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace GameOff2024.Game.Presentation.View
{
    public sealed class TableView : MonoBehaviour
    {
        [SerializeField] private CardView cardView = default;
        [SerializeField] private HandView player = default;
        [SerializeField] private HandView enemy = default;

        public void Init()
        {
            player.Init();
            enemy.Init();
        }

        public async UniTask RenderPlayerHandsAsync(List<HandVO> playerHands, CancellationToken token)
        {
            foreach (var playerHand in playerHands)
            {
                await CreatePlayerHandAsync(playerHand, token);
            }
        }

        public async UniTask RenderEnemyHandsAsync(List<HandVO> enemyHands, CancellationToken token)
        {
            foreach (var enemyHand in enemyHands)
            {
                await CreateEnemyHandAsync(enemyHand, token);
            }
        }

        public async UniTask CreatePlayerHandAsync(HandVO hand, CancellationToken token)
        {
            var card = Instantiate(cardView, transform);
            card.Render(hand.card);
            await player.RenderHandAsync(card, CardConfig.DEAL_SPEED, token);
        }

        public async UniTask CreateEnemyHandAsync(HandVO hand, CancellationToken token)
        {
            var card = Instantiate(cardView, transform);
            card.Render(hand.card);
            await enemy.RenderHandAsync(card, CardConfig.DEAL_SPEED, token);
        }
    }
}