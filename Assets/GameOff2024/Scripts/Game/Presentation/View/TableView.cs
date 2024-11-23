using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2024.Common.Utility;
using UnityEngine;

namespace GameOff2024.Game.Presentation.View
{
    public sealed class TableView : MonoBehaviour
    {
        [SerializeField] private CardView cardView = default;
        [SerializeField] private SecretCardView secretCardView = default;
        [SerializeField] private HandView player = default;
        [SerializeField] private HandView enemy = default;

        public void Init()
        {
            player.Init();
            enemy.Init();
        }

        public async UniTask SetUpAsync(CancellationToken token)
        {
            await (
                secretCardView.HideAsync(CardConfig.DEAL_SPEED, token),
                player.HideAsync(CardConfig.DEAL_SPEED, token),
                enemy.HideAsync(CardConfig.DEAL_SPEED, token)
            );
        }

        public async UniTask RenderSecretCardAsync(CardVO cardVO, CancellationToken token)
        {
            var card = Instantiate(cardView, transform);
            card.Render(cardVO);
            await secretCardView.RenderAsync(card, CardConfig.DEAL_SPEED, token);
        }
        
        public async UniTask OpenSecretCardAsync(CancellationToken token)
        {
            await secretCardView.OpenAsync(CardConfig.ROTATE_SPEED, token);
            await UniTaskHelper.DelayAsync(1.0f, token);
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
            await UniTaskHelper.DelayAsync(CardConfig.DEAL_SPEED / 2.0f, token);
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
            card.Open(CardConfig.ROTATE_SPEED).WithCancellation(token).Forget();
        }

        public async UniTask CreateEnemyHandAsync(HandVO hand, CancellationToken token)
        {
            var card = Instantiate(cardView, transform);
            card.Render(hand.card);
            await enemy.RenderHandAsync(card, CardConfig.DEAL_SPEED, token);
        }

        public async UniTask OpenEnemyHandsAsync(CancellationToken token)
        {
            await enemy.RotateAsync(CardConfig.ROTATE_SPEED, token);
            await UniTaskHelper.DelayAsync(1.0f, token);
        }
    }
}