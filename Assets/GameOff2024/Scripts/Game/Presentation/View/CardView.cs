using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameOff2024.Game.Presentation.View
{
    public sealed class CardView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI rank = default;
        [SerializeField] private Image suit1 = default;
        [SerializeField] private Image suit2 = default;

        public void Render(CardVO cardVO)
        {
            rank.text = cardVO.rank.ToString();
            rank.color = cardVO.suit.color;
            suit1.sprite = cardVO.suit.icon;
            suit1.color = cardVO.suit.color;
            suit2.sprite = cardVO.suit.icon;
            suit2.color = cardVO.suit.color;
        }
    }
}