using R3;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameOff2024.Game.Presentation.View
{
    public sealed class BetView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI num = default;
        [SerializeField] private Button plus = default;
        [SerializeField] private Button minus = default;

        private readonly Subject<int> _bet = new();
        public Observable<int> bet => _bet;

        public void Init()
        {
            plus.onClick.AddListener(() => _bet?.OnNext(1));
            minus.onClick.AddListener(() => _bet?.OnNext(-1));
        }

        public void Render(int value)
        {
            num.text = $"{value}";
        }

        public void ActivatePlus(bool value)
        {
            plus.interactable = value;
        }

        public void ActivateMinus(bool value)
        {
            minus.interactable = value;
        }
    }
}