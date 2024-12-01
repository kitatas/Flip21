using GameOff2024.Common.Presentation.View.Button;
using R3;
using TMPro;
using UnityEngine;

namespace GameOff2024.Game.Presentation.View
{
    public sealed class BetView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI num = default;
        [SerializeField] private CommonButtonView plus = default;
        [SerializeField] private CommonButtonView minus = default;
        [SerializeField] private CommonButtonView decision = default;

        private readonly Subject<int> _bet = new();
        public Observable<int> bet => _bet;

        public void Init()
        {
            plus.AddAction(() => _bet?.OnNext(ChipConfig.BET_RATE));
            minus.AddAction(() => _bet?.OnNext(ChipConfig.BET_RATE * -1));
        }

        public void Render(int value)
        {
            num.text = $"{value:N0}";
        }

        public void ActivatePlus(bool value)
        {
            plus.SetInteractable(value);
        }

        public void ActivateMinus(bool value)
        {
            minus.SetInteractable(value);
            decision.SetInteractable(value);
        }
    }
}