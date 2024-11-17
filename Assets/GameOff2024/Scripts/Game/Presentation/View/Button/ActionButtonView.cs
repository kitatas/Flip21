using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2024.Common.Presentation.View.Button;
using UnityEngine;

namespace GameOff2024.Game.Presentation.View.Button
{
    public sealed class ActionButtonView : BaseButtonView
    {
        [SerializeField] private UserAction userAction = default;

        public async UniTask<UserAction> DecisionAsync(CancellationToken token)
        {
            await OnClickAsync(token);
            return userAction;
        }
    }
}