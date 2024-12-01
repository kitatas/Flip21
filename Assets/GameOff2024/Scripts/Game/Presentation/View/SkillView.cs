using DG.Tweening;
using TMPro;
using UnityEngine;

namespace GameOff2024.Game.Presentation.View
{
    public sealed class SkillView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI chipGetRate = default;
        [SerializeField] private TextMeshProUGUI chipLostRate = default;
        private Tween _tween;

        public void Render((int get, int lost) prev, (int get, int lost) current)
        {
            _tween?.Kill(true);
            _tween = DOTween.Sequence()
                .Append(DOTween.To(
                    () => prev.get,
                    RenderGet,
                    current.get,
                    UiConfig.COUNT_UP_DURATION
                ))
                .Join(DOTween.To(
                    () => prev.lost,
                    RenderLost,
                    current.lost,
                    UiConfig.COUNT_UP_DURATION
                ));
        }

        private void RenderGet(int value)
        {
            chipGetRate.text = $"{value:N0}";
        }

        private void RenderLost(int value)
        {
            chipLostRate.text = $"{value:N0}";
        }
    }
}