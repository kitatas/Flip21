using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace GameOff2024.Game.Presentation.View
{
    public sealed class FlashView : MonoBehaviour
    {
        [SerializeField] private Graphic graphic = default;

        private void Awake()
        {
            graphic
                .DOFade(0.0f, 0.5f)
                .SetEase(Ease.InQuad)
                .SetLoops(-1, LoopType.Yoyo)
                .SetLink(gameObject);
        }
    }
}