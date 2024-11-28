using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace GameOff2024.Common.Presentation.View.Modal
{
    public sealed class LoadModalView : BaseModalView
    {
        [SerializeField] private Image icon = default;

        public void Init()
        {
            RotateIcon();
            Hide(0.0f);
        }

        private void RotateIcon()
        {
            icon.rectTransform
                .DORotate(new Vector3(0.0f, 0.0f, -360.0f), 1.0f, RotateMode.FastBeyond360)
                .SetEase(Ease.Linear)
                .SetLoops(-1)
                .SetLink(gameObject);
        }
    }
}