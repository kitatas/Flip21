using DG.Tweening;
using TMPro;
using UniEx;
using UnityEngine;
using UnityEngine.UI;

namespace GameOff2024.Game.Presentation.View
{
    public sealed class CardView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI rank = default;
        [SerializeField] private Image suit1 = default;
        [SerializeField] private Image suit2 = default;
        [SerializeField] private Image background = default;

        public void Render(CardVO cardVO)
        {
            rank.text = cardVO.GetRankString();
            rank.color = cardVO.suit.color;
            suit1.sprite = cardVO.suit.icon;
            suit1.color = cardVO.suit.color;
            suit2.sprite = cardVO.suit.icon;
            suit2.color = cardVO.suit.color;
        }

        public void ActivateBackground(bool value) => background.gameObject.SetActive(value);

        public Tween TweenX(float value, float duration)
        {
            return transform.ToRectTransform()
                .DOAnchorPosX(value, duration);
        }

        public Tween TweenY(float value, float duration)
        {
            return transform.ToRectTransform()
                .DOAnchorPosY(value, duration);
        }

        public Tween Open(float duration)
        {
            return DOTween.Sequence()
                .Append(RotateY(90.0f, duration))
                .AppendCallback(() => ActivateBackground(false))
                .Append(RotateY(270.0f, 0.0f))
                .Append(RotateY(360.0f, duration));
        }

        public Tween RotateY(float value, float duration)
        {
            return transform.ToRectTransform()
                .DORotate(new Vector3(0.0f, value, 0.0f), duration, RotateMode.FastBeyond360);
        }
    }
}