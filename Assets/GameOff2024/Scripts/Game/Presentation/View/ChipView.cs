using DG.Tweening;
using TMPro;
using UnityEngine;

namespace GameOff2024.Game.Presentation.View
{
    public sealed class ChipView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI chip = default;
        private Tween _tween;

        public void Render(int prev, int current)
        {
            _tween?.Kill(true);
            _tween = DOTween.To(
                () => prev,
                Render,
                current,
                UiConfig.COUNT_UP_DURATION
            );
        }

        public void Render(int value)
        {
            chip.text = $"{value:N0}";
        }
    }
}