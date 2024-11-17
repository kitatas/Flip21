using System.Threading;
using Cysharp.Threading.Tasks;
using GameOff2024.Game.Presentation.View.Button;
using UniEx;
using UnityEngine;

namespace GameOff2024.Game.Presentation.View
{
    public sealed class ActionView : MonoBehaviour
    {
        [SerializeField] private ActionButtonView[] actionButtonViews = default;

        public void Init()
        {
            SetInteractableAll(false);
        }

        public async UniTask<UserAction> DecisionActionAsync(CancellationToken token)
        {
            SetInteractableAll(true);

            var (_, userAction) = await UniTask
                .WhenAny(actionButtonViews.Select(x => x.DecisionAsync(token)));

            SetInteractableAll(false);

            return userAction;
        }

        private void SetInteractableAll(bool value)
        {
            actionButtonViews.Each(x => x.SetInteractable(value));
        }
    }
}